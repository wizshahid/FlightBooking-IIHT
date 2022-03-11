using System;
using System.Collections.Generic;
using Utility.Enums;

namespace AirlineService.Models
{
    public class FlightResponse
    {
        public Guid InventoryId { get; set; }

        public string AirlineName { get; set; }

        public string FlightNumber { get; set; }

        public DateTime Date { get; set; }

        public string FromPlace { get; set; }

        public string ToPlace { get; set; }

        public int Price { get; set; }

        public string LogoPath { get; set; }

        public FlightType FlightType { get; set; }
    }

    public class FlightList
    {
        public List<FlightResponse> OnewayFlight { get; set; }

        public List<FlightResponse> ReturnFlight { get; set; }
    }
}
