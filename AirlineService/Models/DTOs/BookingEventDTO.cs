using System;

namespace AirlineService.Models.DTOs
{
    public class BookingEventDTO : BookingDTO
    {
        public Guid Id { get; set; }

        public Guid FlightId { get; set; }

        public Guid UserId { get; set; }

        public string AirlineName { get; set; }

        public string FlightNumber { get; set; }

        public string FromPlace { get; set; }

        public decimal Price { get; set; }

        public string ToPlace { get; set; }

        public string LogoPath { get; set; }
    }
}
