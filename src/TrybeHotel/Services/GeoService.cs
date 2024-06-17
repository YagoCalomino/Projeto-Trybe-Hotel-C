using System.Net.Http;
using System.Text.Json;
using TrybeHotel.Dto;
using TrybeHotel.Repository;

namespace TrybeHotel.Services
{
    public class GeoService : IGeoService
    {
         private readonly HttpClient _client;
        public GeoService(HttpClient client)
        {
            _client = client;
        }

        // 11. Desenvolva o endpoint GET /geo/status
        public async Task<object> GetGeoStatus()
        {
            HttpRequestMessage mensagemRequisicao = new HttpRequestMessage(HttpMethod.Get, "https://nominatim.openstreetmap.org/status.php?format=json");
            mensagemRequisicao.Headers.Add("Accept", "application/json");
            mensagemRequisicao.Headers.Add("User-Agent", "aspnet-user-agent");

            HttpResponseMessage resposta = await _client.SendAsync(mensagemRequisicao);

            if (resposta.IsSuccessStatusCode)
            {
                string conteudo = await resposta.Content.ReadAsStringAsync();
                return conteudo;
            }
            else
            {
                return null!;
            }
        }
        
        // 12. Desenvolva o endpoint GET /geo/address
        public async Task<GeoDtoResponse> GetGeoLocation(GeoDto geoDto)
        {
            var endereco = $"https://nominatim.openstreetmap.org/search?street={geoDto.Address}&city={geoDto.City}&state={geoDto.State}&format=json&limit=1";

            var mensagemRequisicao = new HttpRequestMessage(HttpMethod.Get, endereco);

            mensagemRequisicao.Headers.Add("Accept", "application/json");
            mensagemRequisicao.Headers.Add("User-Agent", "aspnet-user-agent");

            var resposta = await _client.SendAsync(mensagemRequisicao);

            if (!resposta.IsSuccessStatusCode)
                return default!;

            var conteudoResposta = await resposta.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<List<GeoDtoResponse>>(conteudoResposta);

            return resultado!.First();
        }

        // 12. Desenvolva o endpoint GET /geo/address
        public async Task<List<GeoDtoHotelResponse>> GetHotelsByGeo(GeoDto geoDto, IHotelRepository repository)
        {
            var hoteis = repository.GetHotels();
            var tarefas = hoteis.Select(async hotel =>
            {
                GeoDto geoHotel = new()
                {
                    Address = hotel.Address,
                    City = hotel.CityName,
                    State = hotel.State
                };
                GeoDtoResponse? geoCliente = await GetGeoLocation(geoDto);
                GeoDtoResponse? geoHotelResposta = await GetGeoLocation(geoHotel);
                int distancia = 0;
                if (geoCliente != null && geoHotelResposta != null)
                    distancia = CalculateDistance(geoCliente.lat!, geoCliente.lon!, geoHotelResposta.lat!, geoHotelResposta.lon!);
                return new GeoDtoHotelResponse
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    CityName = hotel.CityName,
                    State = hotel.State,
                    Distance = distancia
                };
            });
            var todosResultados = await Task.WhenAll(tarefas);
            return todosResultados.ToList();
        }
        public int CalculateDistance (string latitudeOrigin, string longitudeOrigin, string latitudeDestiny, string longitudeDestiny) {
            double latOrigin = double.Parse(latitudeOrigin.Replace('.',','));
            double lonOrigin = double.Parse(longitudeOrigin.Replace('.',','));
            double latDestiny = double.Parse(latitudeDestiny.Replace('.',','));
            double lonDestiny = double.Parse(longitudeDestiny.Replace('.',','));
            double R = 6371;
            double dLat = radiano(latDestiny - latOrigin);
            double dLon = radiano(lonDestiny - lonOrigin);
            double a = Math.Sin(dLat/2) * Math.Sin(dLat/2) + Math.Cos(radiano(latOrigin)) * Math.Cos(radiano(latDestiny)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
            double distance = R * c;
            return int.Parse(Math.Round(distance,0).ToString());
        }

        public double radiano(double degree) {
            return degree * Math.PI / 180;
        }

    }
}