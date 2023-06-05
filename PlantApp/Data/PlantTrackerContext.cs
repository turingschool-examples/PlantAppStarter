using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantApp.Models;

namespace PlantApp.Data
{
    public class PlantTrackerContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                "Host=localhost;Username=postgres;Password=password123;Database=PlantTracker";
            optionsBuilder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        }
    }
}
