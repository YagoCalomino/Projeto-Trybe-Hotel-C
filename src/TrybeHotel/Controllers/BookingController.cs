using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

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
        [Authorize(Policy = "Client")]
        public IActionResult Add([FromBody] BookingDtoInsert bookingInsert){
            try
            {
                var token = HttpContext.User.Identity as ClaimsIdentity;
                var emailClaim = token?.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
                var email = emailClaim?.Value;

                var newBooking = _repository.Add(bookingInsert, email!);
                return StatusCode(201, newBooking);
            }
            catch (Exception ex)
            {
                var errorMessage = new { message = ex.Message };
                return BadRequest(errorMessage);
            }
        }


        [HttpGet("{Bookingid}")]
        [Authorize(Policy = "Client")]
        public IActionResult GetBooking(int Bookingid){
            try
            {
                var token = HttpContext.User.Identity as ClaimsIdentity;
                var emailClaim = token?.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
                var email = emailClaim?.Value;

                var booking = _repository.GetBooking(Bookingid, email!);

                return Ok(booking);
            }
            catch (UnauthorizedAccessException ex)
            {
                var unauthorizedMessage = new { message = ex.Message };
                return Unauthorized(unauthorizedMessage);
            }
            catch (Exception ex)
            {
                var errorMessage = new { message = ex.Message };
                return BadRequest(errorMessage);
            }
        }
    }
}