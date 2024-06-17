using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TrybeHotel.Dto;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("booking")]
  
    public class BookingController : Controller
    {
        private readonly IBookingRepository _repository;
        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] BookingDtoInsert bookingInsert){
            if (bookingInsert == null)
            {
                return BadRequest(new { message = "Booking data is required" });
            }

            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized(new { message = "Invalid user" });
            }

            try
            {
                var newBooking = _repository.Add(bookingInsert, email);
                return CreatedAtAction(nameof(GetBooking), new { BookingId = newBooking.BookingId }, newBooking);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("{Bookingid}")]
         [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "Client")]
        public IActionResult GetBooking(int Bookingid){
            var t = HttpContext.User.Identity as ClaimsIdentity;
            var result = t?.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;

            try
            {
                return Ok(_repository.GetBooking(Bookingid, result!));
            }
            catch (Exception error)
            {
                return Unauthorized(new { message = error.Message });
            }
        }
    }
}