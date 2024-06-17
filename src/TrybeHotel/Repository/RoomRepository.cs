using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 7. Refatore o endpoint GET /room
        public IEnumerable<RoomDto> GetRooms(int HotelId)
          {
            var salas = _context.Rooms.Where(s => s.HotelId == HotelId).ToList();
            var hoteis = _context.Hotels.ToList();
            var cidades = _context.Cities.ToList();

            return salas.Select(sala =>
            {
                var hotelEncontrado = hoteis.FirstOrDefault(h => h.HotelId == sala.HotelId);
                var cidadeEncontrada = cidades.FirstOrDefault(c => c.CityId == hotelEncontrado!.CityId);
                return new RoomDto
                {
                    RoomId = sala.RoomId,
                    Name = sala.Name,
                    Capacity = sala.Capacity,
                    Image = sala.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = hotelEncontrado!.HotelId,
                        Name = hotelEncontrado.Name,
                        Address = hotelEncontrado.Address,
                        CityId = cidadeEncontrada!.CityId,
                        CityName = cidadeEncontrada.Name,
                        State = sala.Hotel!.City!.State
                    }
                };
            }).ToList();
        }

        // 8. Refatore o endpoint POST /room
        public RoomDto AddRoom(Room room) {
            _context.Rooms.Add(room);
            _context.SaveChanges();

            var hotelEncontrado = _context.Hotels.FirstOrDefault(h => h.HotelId == room.HotelId);
            var cidadeEncontrada = _context.Cities.FirstOrDefault(c => c.CityId == hotelEncontrado!.CityId);

            return new RoomDto
            {
                RoomId = room.RoomId,
                Name = room.Name,
                Capacity = room.Capacity,
                Image = room.Image,
                Hotel = new HotelDto
                {
                    HotelId = hotelEncontrado!.HotelId,
                    Name = hotelEncontrado.Name,
                    Address = hotelEncontrado.Address,
                    CityId = cidadeEncontrada!.CityId,
                    CityName = cidadeEncontrada.Name,
                    State = room.Hotel!.City!.State
                }
            };
        }

        public void DeleteRoom(int RoomId) {
                        {
            var room = _context.Rooms.Find(RoomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
    }
}
}