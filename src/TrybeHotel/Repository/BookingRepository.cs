using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 9. Refatore o endpoint POST /booking
        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            var user = _context.Users.Where(u => u.Email == email).FirstOrDefault();
            var selectedRoom = GetRoomById(booking.RoomId);

            var newBookingEntity = _context.Bookings.Add(new Booking
            {
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                RoomId = booking.RoomId,
                UserId = user!.UserId,
            }).Entity;

            if (selectedRoom.Capacity < newBookingEntity.GuestQuant)
            {
                var capacityErrorMessage = "Guest quantity over room capacity";
                throw new Exception(capacityErrorMessage);
            }

            _context.SaveChanges();

            return GenerateBookingResponse(newBookingEntity);
        }

        // 10. Refatore o endpoint GET /booking
        public BookingResponse GetBooking(int bookingId, string email)
        {
            var booking = _context.Bookings
                .Where(bk => bk.BookingId == bookingId)
                .Include(b => b.User)
                .FirstOrDefault();

            if (booking == null)
            {
                var notFoundMessage = "Book not found";
                throw new Exception(notFoundMessage);
            }

            bool isAuthorized = booking.BookingId == bookingId && booking.User!.Email == email;

            if (!isAuthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return GenerateBookingResponse(booking);
        }

        public Room GetRoomById(int RoomId)
        {
            var room = _context.Rooms.Find(RoomId);

            if (room == null)
                throw new Exception("Room not found");

            return room;
        }

        private BookingResponse GenerateBookingResponse(Booking booking)
        {
            var room = GetRoomById(booking.RoomId);
            var hotel = _context.Hotels
                .Where(ht => ht.HotelId == room.HotelId)
                .Include(h => h.City)
                .First();

            return new BookingResponse
            {
                BookingId = booking.BookingId,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                Room = new RoomDto
                {
                    RoomId = room.RoomId,
                    Capacity = room.Capacity,
                    Image = room.Image,
                    Name = room.Name,
                    Hotel = new HotelDto
                    {
                        HotelId = hotel.HotelId,
                        Address = hotel.Address,
                        CityId = hotel.CityId,
                        Name = hotel.Name,
                        CityName = hotel.City!.Name,
                        State = hotel.City!.State
                    }
                }
            };
        }
    }
}