using AirlineService.Models;
using System.Collections.Generic;

namespace AirlineService.Services.Airlines
{
    public interface IAirlineManager 
    {
        Airline Add(Airline airline);

        Airline Update(Airline airline);

        List<Airline> GetAirlines();
    }
}
