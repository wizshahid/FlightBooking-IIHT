using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Utility.Enums;

namespace AirlineService.Models.DTOs
{
    public class BookingDTO
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }

        [Range(0, 100)]
        public int NoOfSeats { get; set; }

        public Meals Meals { get; set; }

        public DateTime Date { get; set; }

        public FlightType FlightType { get; set; }

        [Required]
        public List<BookingDetailDTO> BookingDetails { get; set; }
    }
}
