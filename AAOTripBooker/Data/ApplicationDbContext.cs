using Microsoft.EntityFrameworkCore;
using AAOTripBooker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AAOTripBooker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverPeriod> DriverPeriods { get; set; }
        public DbSet<DriverTrip> DriverTrips { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DriverTrip>().
                HasKey(d => new { d.DriverId, d.TripId });
            
        }

    }
}
