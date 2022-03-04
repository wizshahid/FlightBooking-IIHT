using AirlineService.Models;
using AirlineService.Models.DTOs;
using System;
using System.Collections.Generic;
using Utility.Enums;

namespace AirlineService.Services.Airlines
{
    public interface IAirlineManager 
    {
        Airline Add(Airline airline, string host);

        AirlineResponse AirlineDetails(Guid airline);

        Airline Update(Airline airline);

        Airline ChangeAirlineStatus(Guid id, AirlineStatus status);

        List<Airline> GetAirlines(bool fetchOnlyActive);
    }
}
