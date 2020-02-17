using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Reports.Core.Models;
using Reports.Data.Configurations;

namespace Reports.Data
{
    public class ReportsDbContext : IdentityDbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public ReportsDbContext(DbContextOptions<ReportsDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new CityConfiguration());

            builder
                .ApplyConfiguration(new TripConfiguration());
        }
    }
}
