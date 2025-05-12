using AirportWebLab.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AirportWebLab.Data
{
    public class AirlineContext : DbContext
    {
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Company> Companies { get; set; }

        public AirlineContext(DbContextOptions<AirlineContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Boeing" },
                new Manufacturer { Id = 2, Name = "Airbus" }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "SkyLines" },
                new Company { Id = 2, Name = "AirFreedom" }
            );
        }
    }

}
