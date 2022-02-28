
using AirlineService.Models;
using System.Collections.Generic;
using System.Linq;
using Utility.Exceptions;

namespace AirlineService.Services.Airlines
{
    public class AirlineManager : IAirlineManager
    {
        private readonly AppDbContext context;

        public AirlineManager(AppDbContext context)
        {
            this.context = context;
        }

        public Airline Add(Airline airline)
        {
            if (context.Airlines.Any(x => x.Name == airline.Name))
                throw new AppException($"Airline with the name {{{airline.Name}}} already exists");

            context.Airlines.Add(airline);
            context.SaveChanges();
            return airline;
        }

        public List<Airline> GetAirlines()
        {
            return context.Airlines.ToList();
        }

        public Airline Update(Airline airline)
        {
            if (context.Airlines.Any(x => x.Name == airline.Name && x.Id != airline.Id))
                throw new AppException($"Airline with the name {{{airline.Name}}} already exists");

            context.Entry(airline).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return airline;
        }
    }
}
