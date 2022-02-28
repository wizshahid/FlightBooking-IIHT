using System;
using Utility.Enums;

namespace AirlineService.Models
{
    public class Airline
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContactNo { get; set; }

        public string ContactAddress { get; set; }

        public string LogoPath { get; set; }

        public AirlineStatus Status { get; set; }
    }
}
