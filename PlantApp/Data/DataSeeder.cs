using PlantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantApp.Data
{
    public class DataSeeder
    {
        public static void SeedPlantsAndRooms(PlantTrackerContext context)
        {
            if (!context.Rooms.Any())
            {
                var fern_plant = new Plant
                {
                    Type = "Fern",
                    PurchaseDate = DateTime.Parse("1975-06-15T13:45:30-07:00").ToUniversalTime()
                };
                var rubber_plant = new Plant
                {
                    Type = "Rubber",
                    PurchaseDate = DateTime.Parse("2021-01-15T11:45:02-07:00").ToUniversalTime()
                };
                var jade_plant = new Plant
                {
                    Type = "Jade",
                    PurchaseDate = DateTime.Parse("2021-01-15T11:45:02-07:00").ToUniversalTime()
                };

                var rooms = new List<Room>
                {
                    new Room
                    {
                        Name = "Office",
                        Plants = new List<Plant> { fern_plant, rubber_plant }
                    },
                    new Room
                    {
                        Name = "Kitchen",
                        Plants = new List<Plant> { jade_plant }
                    }
                };
                context.Rooms.AddRange(rooms);
                context.SaveChanges();
            }
        }
    }
}
