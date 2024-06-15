using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        private readonly IHotelRepository _repository;
        public RoomRepository(ITrybeHotelContext context, IHotelRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // 7. Refatore o endpoint GET /room
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            var roomList = _context.Rooms
                .Where(room => room.HotelId == HotelId)
                .Include(rm => rm.Hotel)
                .ThenInclude(hotel => hotel!.City)
                .Select(r => new RoomDto
                {
                    RoomId = r.RoomId,
                    Name = r.Name,
                    Capacity = r.Capacity,
                    Image = r.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = r.Hotel!.HotelId,
                        Name = r.Hotel.Name,
                        Address = r.Hotel.Address,
                        CityId = r.Hotel.CityId,
                        CityName = r.Hotel.City!.Name,
                        State = r.Hotel.City!.State
                    }
                });

            return roomList;
        }

        // 8. Refatore o endpoint POST /room
        public RoomDto AddRoom(Room room) {
        _context.Rooms.Add(room);
        _context.SaveChanges();

            var addedRoom = _context.Rooms
                .Where(r => r.RoomId == room.RoomId)
                .Include(rm => rm.Hotel)
                .ThenInclude(hotel => hotel!.City)
                .First();

            return new RoomDto
            {
                RoomId = addedRoom.RoomId,
                Name = addedRoom.Name,
                Capacity = addedRoom.Capacity,
                Image = addedRoom.Image,
                Hotel = new HotelDto
                {
                    HotelId = addedRoom.Hotel!.HotelId,
                    Name = addedRoom.Hotel?.Name,
                    Address = addedRoom.Hotel?.Address,
                    CityId = addedRoom.Hotel!.CityId,
                    CityName = addedRoom.Hotel.City!.Name,
                    State = addedRoom.Hotel.City!.State
                }
            };
        }

        public void DeleteRoom(int RoomId) {
            var room = _context.Rooms.Find(RoomId) ?? throw new Exception("Room not found");

            _context.Rooms.Remove(room);
        }
    }
}