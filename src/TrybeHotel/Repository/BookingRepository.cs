using TrybeHotel.Models;
using TrybeHotel.Dto;

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
            var sala = _context.Rooms.FirstOrDefault(s => s.RoomId == booking.RoomId);

            if (sala is null)
            {
                throw new ArgumentException("RoomId inválido");
            }

            if (booking.GuestQuant > sala.Capacity)
            {
                throw new ArgumentException("Quantidade de hóspedes excede a capacidade da sala");
            }

            var usuario = _context.Users.FirstOrDefault(u => u.Email == email);

            if (usuario == null)
            {
                throw new ArgumentException("Email de usuário inválido");
            }

            var reserva = new Booking
            {
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                RoomId = booking.RoomId,
                UserId = usuario.UserId
            };

            _context.Bookings.Add(reserva);
            _context.SaveChanges();

            var hotel = _context.Hotels.FirstOrDefault(h => h.HotelId == sala.HotelId);
            var cidade = _context.Cities.FirstOrDefault(c => c.CityId == hotel!.CityId);

            return new BookingResponse
            {
                BookingId = reserva.BookingId,
                CheckIn = reserva.CheckIn,
                CheckOut = reserva.CheckOut,
                GuestQuant = reserva.GuestQuant,
                Room = new RoomDto
                {
                    RoomId = sala.RoomId,
                    Name = sala.Name,
                    Capacity = sala.Capacity,
                    Image = sala.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = hotel!.HotelId,
                        Name = hotel.Name,
                        Address = hotel.Address,
                        CityId = cidade!.CityId,
                        CityName = cidade.Name,
                        State = sala.Hotel!.City!.State
                    }
                }
            };
        }

        // 10. Refatore o endpoint GET /booking
        public BookingResponse GetBooking(int bookingId, string email)
        {
            var reserva = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (reserva is null)
            {
                throw new ArgumentException("Reserva não encontrada");
            }

            var usuario = _context.Users.FirstOrDefault(u => u.UserId == reserva.UserId);

            if (usuario == null || usuario.Email != email)
            {
                throw new ArgumentException("Usuário não autorizado a acessar esta reserva");
            }

            var sala = _context.Rooms.FirstOrDefault(r => r.RoomId == reserva.RoomId);
            var hotel = _context.Hotels.FirstOrDefault(h => h.HotelId == sala!.HotelId);
            var cidade = _context.Cities.FirstOrDefault(c => c.CityId == hotel!.CityId);

            return new BookingResponse
            {
                BookingId = reserva.BookingId,
                CheckIn = reserva.CheckIn,
                CheckOut = reserva.CheckOut,
                GuestQuant = reserva.GuestQuant,
                Room = new RoomDto
                {
                    RoomId = sala!.RoomId,
                    Name = sala.Name,
                    Capacity = sala.Capacity,
                    Image = sala.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = hotel!.HotelId,
                        Name = hotel.Name,
                        Address = hotel.Address,
                        CityId = cidade!.CityId,
                        CityName = cidade.Name,
                        State = reserva.Room!.Hotel!.City!.State
                    }
                }
            };
        }

        public Room GetRoomById(int RoomId)
        {
             throw new NotImplementedException();
        }

    }

}