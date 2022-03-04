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

        List<FlightResponse> SearchFlights(SearchParameter parameter);

        FlightResponse GetFlight(Guid id);

        BookingEventDTO BookFlight(Guid flightId, BookingDTO booking);
    }
}
