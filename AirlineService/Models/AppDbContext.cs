using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirlineService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>().HasData(SeedAirportData());

            foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationShip.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<Airline> Airlines { get; set; }

        public DbSet<AirlineInventory> AirlineInventories { get; set; }

        public DbSet<Airport> Airports { get; set; }

        private static List<Airport> SeedAirportData()
        {
            var airports = new List<Airport>();
            using (var reader = new StreamReader(@"airport-seed.json"))
            {
                string json = reader.ReadToEnd();
                airports = JsonConvert.DeserializeObject<List<Airport>>(json);
            }
            return airports;
        }
    }
}
