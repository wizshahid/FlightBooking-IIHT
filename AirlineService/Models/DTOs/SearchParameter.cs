using System;
using Utility.Enums;

namespace AirlineService.Models
{
    public class SearchParameter
    {
        public DateTime? Date { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string FromPlace { get; set; }

        public string ToPlace { get; set; }

        public string AirlineName { get; set; }

        public FlightType FlightType { get; set; }
    }
}
