using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : Controller
    {
        private readonly ICityRepository _repository;
        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult GetCities(){
            var getAllCities = _repository.GetCities();
            return Ok(getAllCities);
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] City city){
            return Created("", _repository.AddCity(city));
        }
        
        // 3. Desenvolva o endpoint PUT /city
        [HttpPut]
        public IActionResult PutCity([FromBody] City city){
            return Ok(_repository.UpdateCity(city));
        }
    }
}