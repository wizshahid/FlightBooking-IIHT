using AirlineService.Models;
using AirlineService.Services.Airlines;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineManager airlineManager;

        public AirlineController(IAirlineManager airlineManager)
        {
            this.airlineManager = airlineManager;
        }


        [HttpPost("register")]
        public IActionResult Post(Airline airline)
        {
            return Ok(airlineManager.Add(airline));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(airlineManager.GetAirlines());
        }
    }
}
