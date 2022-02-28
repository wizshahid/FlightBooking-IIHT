using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Utility.Enums;

namespace AuthService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new User
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Username = "admin",
                    Password = "admin",
                    Role = UserRole.Admin,
                }
            });
        }

        public DbSet<User> Users { get; set; }
    }
}
