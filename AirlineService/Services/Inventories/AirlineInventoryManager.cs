
using AirlineService.Models;
using AirlineService.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.Enums;
using Utility.Exceptions;

namespace AirlineService.Services.Inventories
{
    public class AirlineInventoryManager : IAirlineInventoryManager
    {
        private readonly HttpContext httpContext;
        private readonly AppDbContext context;

        public AirlineInventoryManager(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            httpContext = contextAccessor.HttpContext;
            this.context = context;
        }

        public AirlineInventory Add(AirlineInventory inventory)
        {
            context.AirlineInventories.Add(inventory);
            context.SaveChanges();
            return inventory;
        }

        public List<AirlineInventory> GetInventories()
        {
            return context.AirlineInventories.ToList();
        }

        public List<Airport> GetAirports()
        {
            return context.Airports.ToList();
        }

        public List<FlightResponse> SearchFlights(SearchParameter parameter)
        {
            var date = parameter.Date ?? DateTime.Now;
            var result = context.AirlineInventories
                .Where(x => x.EndDate > date && x.StartDate < date && x.Airline.Status == AirlineStatus.Active && x.FlightType == parameter.FlightType)
                .Select(x => new FlightResponse
                {
                    InventoryId = x.Id,
                    AirlineName = x.Airline.Name,
                    Date = date,
                    FlightNumber = x.FlightNumber,
                    FromPlace = x.FromPlace.City,
                    ToPlace = x.ToPlace.City,
                    Price = x.TicketPrice,
                    LogoPath = x.Airline.LogoPath,
                    FlightType = x.FlightType
                });

            if (!string.IsNullOrEmpty(parameter.ToPlace))
                result = result.Where(x => x.ToPlace == parameter.ToPlace);

            if (!string.IsNullOrEmpty(parameter.AirlineName))
                result = result.Where(x => x.AirlineName == parameter.AirlineName);

            if (!string.IsNullOrEmpty(parameter.FromPlace))
                result = result.Where(x => x.FromPlace == parameter.FromPlace);

            return result.ToList();
        }

        public FlightResponse GetFlight(Guid id)
        {
            var result = context.AirlineInventories.Where(x => x.Id == id).Select(x => new FlightResponse
            {
                InventoryId = x.Id,
                AirlineName = x.Airline.Name,
                Date = DateTime.Now,
                FlightNumber = x.FlightNumber,
                FromPlace = x.FromPlace.City,
                ToPlace = x.ToPlace.City,
                Price = x.TicketPrice,
                LogoPath = x.Airline.LogoPath,
                FlightType = x.FlightType
            });

            return result.FirstOrDefault();
        }

        public AirlineInventory Update(AirlineInventory inventory)
        {
            context.Entry(inventory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return inventory;
        }

        public BookingEventDTO BookFlight(Guid flightId, BookingDTO booking)
        {
            if (booking.NoOfSeats != booking.BookingDetails.Count)
                throw new AppException("The count of details doesn't match with number of seats booked");

            var inventory = context.AirlineInventories.
                Include(x => x.Airline).
                Include(x => x.ToPlace).
                Include(x => x.FromPlace).
                FirstOrDefault(x => x.Id == flightId);

            if (inventory == null)
                throw new AppException("Invalid FlightId");

            var bookingEvent = new BookingEventDTO
            {
                Id = Guid.NewGuid(),
                FlightId = flightId,
                Date = booking.Date,
                Meals = booking.Meals,
                Name = booking.Name,
                Email = booking.Email,
                AirlineName = inventory.Airline.Name,
                FlightNumber = inventory.FlightNumber,
                FromPlace = inventory.FromPlace.City,
                ToPlace = inventory.ToPlace.City,
                BookingDetails = booking.BookingDetails,
                NoOfSeats = booking.NoOfSeats,
                Price = inventory.TicketPrice,
                UserId = GetUserId(),
                LogoPath = inventory.Airline.LogoPath,
                FlightType = inventory.FlightType
            };

            var factory = new ConnectionFactory { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("FlightBooking", false, false, false, null);
            var message = JsonConvert.SerializeObject(bookingEvent);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", "FlightBooking", null, body);

            return bookingEvent;
        }

        private Guid GetUserId() => Guid.Parse(httpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("UserId")).Value);
    }
}
