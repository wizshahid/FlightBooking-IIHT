using AirlineService.Models;
using AirlineService.Models.DTOs;
using AirlineService.Services.Inventories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AirlineService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineInventoryController : ControllerBase
    {
        private readonly IAirlineInventoryManager manager;

        public AirlineInventoryController(IAirlineInventoryManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(AirlineInventory inventory)
        {
            return Ok(manager.Add(inventory));
        }

        [HttpPost("/api/flight/search")]
        public IActionResult SearchAirline(SearchParameter parameter)
        {
            return Ok(manager.SearchFlights(parameter));
        }

        [HttpGet("/api/flight/airports")]
        public IActionResult GetAirports()
        {
            return Ok(manager.GetAirports());
        }

        [HttpPost("/api/booking/{flightid}")]
        [Authorize(Roles = "User")]
        public IActionResult BookFlight(Guid flightid, BookingDTO booking)
        {
            return Ok(manager.BookFlight(flightid, booking));
        }
    }
}
