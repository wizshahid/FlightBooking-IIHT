using BookingService.Models;
using System;
using System.Collections.Generic;

namespace BookingService.Services
{
    public interface IBookingManager
    {
        Booking Add(Booking booking);

        Booking GetBooking(Guid pnr);

        List<Booking> GetByEmail(string email);

        Booking CancelBooking(Guid pnr);
    }
}
