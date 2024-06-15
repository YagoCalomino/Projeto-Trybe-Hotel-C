using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
using TrybeHotel.Services;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("login")]

    public class LoginController : Controller
    {

        private readonly IUserRepository _repository;
        public LoginController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto login){
            try
            {
                var user = _repository.Login(login);

                var tokenGenerator = new TokenGenerator();
                var generatedToken = tokenGenerator.Generate(user);
                
                return Ok(new { token = generatedToken });
            }
            catch (Exception ex)
            {
                var errorMessage = new { message = ex.Message };
                return Unauthorized(errorMessage);
            }
        }
    }
}