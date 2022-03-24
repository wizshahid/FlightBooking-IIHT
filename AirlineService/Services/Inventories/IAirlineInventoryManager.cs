using AirlineService.Models;
using AirlineService.Models.DTOs;
using System;
using System.Collections.Generic;

namespace AirlineService.Services.Inventories
{
    public interface IAirlineInventoryManager 
    {
        AirlineInventory Add(AirlineInventory airline);

        AirlineInventory Update(AirlineInventory airline);

        List<AirlineInventory> GetInventories();

        List<Airport> GetAirports();

        FlightList SearchFlights(SearchParameter parameter);

        FlightResponse GetFlight(Guid id);

        BookingEventDTO BookFlight(BookingDTO booking);
    }
}
