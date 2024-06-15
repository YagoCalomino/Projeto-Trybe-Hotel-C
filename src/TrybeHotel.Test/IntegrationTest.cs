namespace TrybeHotel.Test;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Diagnostics;
using System.Xml;
using System.IO;
using FluentAssertions;
using TrybeHotel.Dto;
using TrybeHotel.Services;
using System.Net.Http.Headers;

public class LoginJson {
    public string? token { get; set; }
}


public class IntegrationTest: IClassFixture<WebApplicationFactory<Program>>
{
     public HttpClient _clientTest;

     public IntegrationTest(WebApplicationFactory<Program> factory)
    {
        //_factory = factory;
        _clientTest = factory.WithWebHostBuilder(builder => {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TrybeHotelContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<ContextTest>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestDatabase");
                });
                services.AddScoped<ITrybeHotelContext, ContextTest>();
                services.AddScoped<ICityRepository, CityRepository>();
                services.AddScoped<IHotelRepository, HotelRepository>();
                services.AddScoped<IRoomRepository, RoomRepository>();
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<ContextTest>())
                {
                    appContext.Database.EnsureCreated();
                    appContext.Database.EnsureDeleted();
                    appContext.Database.EnsureCreated();
                    appContext.Cities.Add(new City {CityId = 1, Name = "Manaus", State = "AM"});
                    appContext.Cities.Add(new City {CityId = 2, Name = "Palmas", State = "TO"});
                    appContext.SaveChanges();
                    appContext.Hotels.Add(new Hotel {HotelId = 1, Name = "Trybe Hotel Manaus", Address = "Address 1", CityId = 1});
                    appContext.Hotels.Add(new Hotel {HotelId = 2, Name = "Trybe Hotel Palmas", Address = "Address 2", CityId = 2});
                    appContext.Hotels.Add(new Hotel {HotelId = 3, Name = "Trybe Hotel Ponta Negra", Address = "Addres 3", CityId = 1});
                    appContext.SaveChanges();
                    appContext.Rooms.Add(new Room { RoomId = 1, Name = "Room 1", Capacity = 2, Image = "Image 1", HotelId = 1 });
                    appContext.Rooms.Add(new Room { RoomId = 2, Name = "Room 2", Capacity = 3, Image = "Image 2", HotelId = 1 });
                    appContext.Rooms.Add(new Room { RoomId = 3, Name = "Room 3", Capacity = 4, Image = "Image 3", HotelId = 1 });
                    appContext.Rooms.Add(new Room { RoomId = 4, Name = "Room 4", Capacity = 2, Image = "Image 4", HotelId = 2 });
                    appContext.Rooms.Add(new Room { RoomId = 5, Name = "Room 5", Capacity = 3, Image = "Image 5", HotelId = 2 });
                    appContext.Rooms.Add(new Room { RoomId = 6, Name = "Room 6", Capacity = 4, Image = "Image 6", HotelId = 2 });
                    appContext.Rooms.Add(new Room { RoomId = 7, Name = "Room 7", Capacity = 2, Image = "Image 7", HotelId = 3 });
                    appContext.Rooms.Add(new Room { RoomId = 8, Name = "Room 8", Capacity = 3, Image = "Image 8", HotelId = 3 });
                    appContext.Rooms.Add(new Room { RoomId = 9, Name = "Room 9", Capacity = 4, Image = "Image 9", HotelId = 3 });
                    appContext.SaveChanges();
                    appContext.Users.Add(new User { UserId = 1, Name = "Ana", Email = "ana@trybehotel.com", Password = "Senha1", UserType = "admin" });
                    appContext.Users.Add(new User { UserId = 2, Name = "Beatriz", Email = "beatriz@trybehotel.com", Password = "Senha2", UserType = "client" });
                    appContext.Users.Add(new User { UserId = 3, Name = "Laura", Email = "laura@trybehotel.com", Password = "Senha3", UserType = "client" });
                    appContext.SaveChanges();
                    appContext.Bookings.Add(new Booking { BookingId = 1, CheckIn = new DateTime(2023, 07, 02), CheckOut = new DateTime(2023, 07, 03), GuestQuant = 1, UserId = 2, RoomId = 1});
                    appContext.Bookings.Add(new Booking { BookingId = 2, CheckIn = new DateTime(2023, 07, 02), CheckOut = new DateTime(2023, 07, 03), GuestQuant = 1, UserId = 3, RoomId = 4});
                    appContext.SaveChanges();
                }
            });
        }).CreateClient();
    }
 
     private void AuthenticateAdminUser()
    {
        UserDto user = new UserDto
        {
            Email = "ana@trybehotel.com",
            UserType = "admin"
        };
        var token = new TokenGenerator().Generate(user);
        _clientTest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    [Trait("Category", "Meus testes")]
    [Theory(DisplayName = "Executando meus testes")]
    [InlineData("/city")]
    public async Task TestGet(string url)
    {
        var response = await _clientTest.GetAsync(url);
        Assert.Equal(System.Net.HttpStatusCode.OK, response?.StatusCode);
    }
   
       [Trait("Category", "Meus testes")]
    [Theory(DisplayName = "Testa se a rota adiciona uma cidade com sucesso")]
    [InlineData("/city")]
    public async Task TestPostCity(string url)
    {
        var cityMock = new
        {
            Name = "Nome criativo"
        };

        var content = new StringContent(JsonConvert.SerializeObject(cityMock), System.Text.Encoding.UTF8, "application/json");
        var response = await _clientTest.PostAsync(url, content);
        var resStr = await response.Content.ReadAsStringAsync();
        var city = JsonConvert.DeserializeObject<CityDto>(resStr);

        city.Should().BeEquivalentTo(cityMock);
        Assert.Equal(System.Net.HttpStatusCode.Created, response?.StatusCode);
    }

    [Trait("Category", "Meus testes")]
    [Theory(DisplayName = "Testa se a rota /hotel retorna os dados corretos")]
    [InlineData("/hotel")]
    public async Task TestGetHotels(string url)
    {
        var expectedHotels = new List<HotelDto>
        {
            new HotelDto
            {
                HotelId = 1,
                Name = "Trybe Hotel Manaus",
                Address = "Address 1",
                CityId = 1,
                CityName = "Manaus"
            },
            new HotelDto
            {
                HotelId = 2,
                Name = "Trybe Hotel Palmas",
                Address = "Address 2",
                CityId = 2,
                CityName = "Palmas"
            },
            new HotelDto
            {
                HotelId = 3,
                Name = "Trybe Hotel Ponta Negra",
                Address = "Address 3",
                CityId = 1,
                CityName = "Manaus"
            }
        };

        var response = await _clientTest.GetAsync(url);
        var hotelsStr = await response.Content.ReadAsStringAsync();
        var hotels = JsonConvert.DeserializeObject<List<HotelDto>>(hotelsStr);

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        hotels.Should().BeEquivalentTo(expectedHotels);
    }

    [Trait("Category", "Meus testes")]
    [Theory(DisplayName = "Testa se a rota adiciona um hotel com sucesso")]
    [InlineData("/hotel")]
    public async Task TestPostHotel(string url)
    {
        AuthenticateAdminUser();

        var hotelInput = new
        {
            Name = "Trybe Hotel RJ",
            Address = "Avenida Atlântica, 1400",
            CityId = 2
        };
        var expectedHotel = new HotelDto
        {
            HotelId = 4,
            Name = "Trybe Hotel RJ",
            Address = "Avenida Atlântica, 1400",
            CityId = 2,
            CityName = "Palmas"
        };

        var content = new StringContent(JsonConvert.SerializeObject(hotelInput), System.Text.Encoding.UTF8, "application/json");
        var response = await _clientTest.PostAsync(url, content);
        var resStr = await response.Content.ReadAsStringAsync();
        var hotel = JsonConvert.DeserializeObject<HotelDto>(resStr);

        hotel.Should().BeEquivalentTo(expectedHotel);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    }

    [Trait("Category", "Meus testes")]
    [Theory(DisplayName = "Testa se a rota /room retorna os dados corretos")]
    [InlineData("/room/1")]
    public async Task TestGetRooms(string url)
    {
        var expectedRooms = new List<RoomDto>
        {
            new RoomDto
            {
                RoomId = 1,
                Name = "Room 1",
                Capacity = 2,
                Image = "Image 1",
                Hotel = new HotelDto
                {
                    HotelId = 1,
                    Name = "Trybe Hotel Manaus",
                    Address = "Address 1",
                    CityId = 1,
                    CityName = "Manaus"
                }
            },
            new RoomDto
            {
                RoomId = 2,
                Name = "Room 2",
                Capacity = 3,
                Image = "Image 2",
                Hotel = new HotelDto
                {
                    HotelId = 1,
                    Name = "Trybe Hotel Manaus",
                    Address = "Address 1",
                    CityId = 1,
                    CityName = "Manaus"
                }
            },
            new RoomDto
            {
                RoomId = 3,
                Name = "Room 3",
                Capacity = 4,
                Image = "Image 3",
                Hotel = new HotelDto
                {
                    HotelId = 1,
                    Name = "Trybe Hotel Manaus",
                    Address = "Address 1",
                    CityId = 1,
                    CityName = "Manaus"
                }
            }
        };

        var response = await _clientTest.GetAsync(url);
        var roomsStr = await response.Content.ReadAsStringAsync();
        var rooms = JsonConvert.DeserializeObject<List<RoomDto>>(roomsStr);

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        rooms.Should().BeEquivalentTo(expectedRooms);
    }

    [Trait("Category", "Meus testes")]
    [Theory(DisplayName = "Ao adicionar um novo quarto retorna o status code correto")]
    [InlineData("/room")]
    public async Task TestPost(string url)
    {
        AuthenticateAdminUser();

        var roomInput = new
        {
            Name = "Nome criativo",
            Capacity = 1,
            Image = "Imagem",
            HotelId = 1
        };
        var expectedRoom = new RoomDto
        {
            RoomId = 10,
            Name = "Nome criativo",
            Capacity = 1,
            Image = "Imagem",
            Hotel = new HotelDto
            {
                HotelId = 1,
                Name = "Trybe Hotel Manaus",
                Address = "Address 1",
                CityId = 1,
                CityName = "Manaus"
            }
        };

        var content = new StringContent(JsonConvert.SerializeObject(roomInput), System.Text.Encoding.UTF8, "application/json");
        var response = await _clientTest.PostAsync(url, content);
        var resStr = await response.Content.ReadAsStringAsync();
        var room = JsonConvert.DeserializeObject<RoomDto>(resStr);

        room.Should().BeEquivalentTo(expectedRoom);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    }

    [Trait("Category", "Meus testes")]
    [Theory(DisplayName = "Deletar um quarto")]
    [InlineData("/room/1")]
    public async Task TestDeleteRoom(string url)
    {
        AuthenticateAdminUser();

        var response = await _clientTest.DeleteAsync(url);
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response?.StatusCode);
    }
}