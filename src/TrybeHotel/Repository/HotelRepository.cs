using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        //  5. Refatore o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {
            var hotelsList = _context.Hotels
                .Include(hotel => hotel.City)
                .Select(h => new HotelDto
                {
                    HotelId = h.HotelId,
                    Name = h.Name,
                    Address = h.Address,
                    CityId = h.CityId,
                    CityName = h.City!.Name,
                    State = h.City!.State
                }).ToList();

            return hotelsList;
        }

        // 6. Refatore o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            var addedHotel = _context.Hotels.Add(hotel).Entity;
            _context.SaveChanges();

            var hotelDetails = _context.Hotels
                .Where(ht => ht.HotelId == hotel.HotelId)
                .Include(h => h.City)
                .Select(h => new HotelDto
                {
                    HotelId = h.HotelId,
                    Name = h.Name,
                    Address = h.Address,
                    CityId = h.CityId,
                    CityName = h.City!.Name,
                    State = h.City!.State
                }).First();

            return hotelDetails;
        }
    }
}