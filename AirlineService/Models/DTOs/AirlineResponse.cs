using System;
using System.Collections.Generic;
using Utility.Enums;

namespace AirlineService.Models.DTOs
{
    public class AirlineResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContactNo { get; set; }

        public string ContactAddress { get; set; }

        public string LogoPath { get; set; }

        public AirlineStatus Status { get; set; }

        public List<InventoryResponse> Inventories { get; set; }
    }
}
