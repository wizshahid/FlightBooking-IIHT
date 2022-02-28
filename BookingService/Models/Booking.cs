using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utility.Enums;

namespace BookingService.Models
{
    public class Booking
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }

        [Range(0, 100)]
        public int NoOfSeats { get; set; }

        public Guid UserId { get; set; }

        public Meals Meals { get; set; }

        public DateTime Date { get; set; }

        public Guid FlightId { get; set; }

        [Required]
        public string AirlineName { get; set; }

        [Required]
        public string FlightNumber { get; set; }

        [Required]
        public string FromPlace { get; set; }

        [Required]
        public string ToPlace { get; set; }

        public BookingStatus Status { get; set; }

        [Required]
        public ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
