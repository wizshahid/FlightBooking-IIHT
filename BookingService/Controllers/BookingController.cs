using BookingService.Models;
using BookingService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            this.bookingManager = bookingManager;
        }

        [HttpGet("ticket/{pnr}")]
        public IActionResult Get(Guid pnr)
        {
            return Ok(bookingManager.GetBooking(pnr));
        }

        [HttpGet("history/{emailId}")]
        public IActionResult GetByEmail(string emailId)
        {
            return Ok(bookingManager.GetByEmail(emailId));
        }

        [HttpDelete("cancel/{pnr}")]
        public IActionResult Cancel(Guid pnr)
        {
            bookingManager.CancelBooking(pnr);
            return Ok();
        }
    }
}
