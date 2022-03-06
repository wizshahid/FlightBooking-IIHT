using AirlineService.Models;
using AirlineService.Services.Airlines;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Utility.Enums;

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
        public IActionResult Post([FromForm] Airline airline)
        {
            ModelState.Validate();
            return Ok(airlineManager.Add(airline, HttpContext.Request.Scheme + "://" + HttpContext.Request.Host));
        }

        [HttpGet]
        public IActionResult Get(bool fetchOnlyActive)
        {
            return Ok(airlineManager.GetAirlines(fetchOnlyActive));
        }

        [HttpPut("changestatus/{id}/{status}")]
        public IActionResult ChangeStatus(Guid id, AirlineStatus status)
        {
            return Ok(airlineManager.ChangeAirlineStatus(id, status));
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(airlineManager.AirlineDetails(id));
        }
    }
}
