using AirlineService.Models;
using AirlineService.Models.DTOs;
using AirlineService.Services.Inventories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Utility.Exceptions;

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
            ModelState.Validate();
            return Ok(manager.Add(inventory));
        }

        [HttpPost("/api/flight/search")]
        public IActionResult SearchAirline(SearchParameter parameter)
        {
            return Ok(manager.SearchFlights(parameter));
        }

        [HttpGet("/api/flight/{id}")]
        public IActionResult GetFlight(Guid id)
        {
            return Ok(manager.GetFlight(id));
        }

        [HttpGet("/api/flight/airports")]
        public IActionResult GetAirports()
        {
            return Ok(manager.GetAirports());
        }

        [HttpPost("/api/booking/{flightid}")]
        [Authorize]
        public IActionResult BookFlight(Guid flightid, BookingDTO booking)
        {
            ModelState.Validate();
            return Ok(manager.BookFlight(flightid, booking));
        }
    }
}
