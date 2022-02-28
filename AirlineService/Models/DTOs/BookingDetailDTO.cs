using System.ComponentModel.DataAnnotations;
using Utility.Enums;

namespace AirlineService.Models.DTOs
{
    public class BookingDetailDTO
    {
        [Required]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public int SeatNumber { get; set; }
    }
}
