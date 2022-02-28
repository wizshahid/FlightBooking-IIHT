using System;

namespace AirlineService.Models
{
    public class SearchParameter
    {
        public DateTime? Date { get; set; }

        public string FromPlace { get; set; }

        public string ToPlace { get; set; }
    }
}
