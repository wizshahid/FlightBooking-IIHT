using BookingService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Enums;
using Utility.Exceptions;

namespace BookingService.Services
{
    public class BookingManager : IBookingManager
    {
        private readonly AppDbContext context;
        private readonly HttpContext httpContext;

        public BookingManager(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            httpContext = contextAccessor.HttpContext;
            this.context = context;
        }

        private Guid GetUserId() => Guid.Parse(httpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("UserId")).Value);

        public Booking Add(Booking booking)
        {
            booking.Status = BookingStatus.Success;
            context.Add(booking);
            context.SaveChanges();
            return booking;
        }

        public void CancelBooking(Guid pnr)
        {
            var booking = context.Bookings.Find(pnr);

            if (booking == null)
                throw new AppException("Invalid PNR");

            if (booking.Status == BookingStatus.Cancel)
                throw new AppException("Booking is already cancelled");

            if (booking.UserId != GetUserId())
                throw new AppException("You don't have access to cancel this booking");

            booking.Status = BookingStatus.Cancel;
            context.SaveChanges();
        }

        public Booking GetBooking(Guid pnr)
        {
            var booking = context.Bookings.
                Include(x => x.BookingDetails).
                FirstOrDefault(x => x.Id == pnr);

            if (booking == null || booking.Status == BookingStatus.Cancel)
                throw new AppException($"Booking does not existing with the PNR {{{pnr}}}");

            return booking;
        }

        public List<Booking> GetByEmail(string email)
        {
            return context.Bookings.
                Include(x => x.BookingDetails).
                Where(x => x.Email == email && x.UserId == GetUserId() && x.Status == BookingStatus.Success).ToList();
        }
    }
}
