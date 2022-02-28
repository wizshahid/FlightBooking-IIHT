using System;
using System.ComponentModel.DataAnnotations.Schema;
using Utility.Enums;

namespace AirlineService.Models
{
    public class AirlineInventory
    {
        public Guid Id { get; set; }

        public Guid AirlineId { get; set; }

        [ForeignKey(nameof(AirlineId))]
        public Airline Airline { get; set; }

        public string FlightNumber { get; set; }

        public Guid FromPlaceId { get; set; }

        [ForeignKey(nameof(FromPlaceId))]
        public Airport FromPlace { get; set; }

        public Guid ToPlaceId { get; set; }

        [ForeignKey(nameof(ToPlaceId))]
        public Airport ToPlace { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ScheduledDays ScheduledDays { get; set; }

        public string InstrumentUsed { get; set; }

        public int BusinessClassSeats { get; set; }

        public int NonBusinessClassSeats { get; set; }

        public int TicketPrice { get; set; }

        public int NumberOfRows { get; set; }

        public Meals Meals { get; set; }
    }
}
