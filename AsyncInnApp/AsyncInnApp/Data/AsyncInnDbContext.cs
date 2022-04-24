using AsyncInnApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
      
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
       
        public DbSet<HotelRoom> HotelRooms { get; set; }

        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }


        //public int id { set; get; }
        //public string name { set; get; }
        //public string streetAddress { set; get; }
        //public string city { set; get; }
        //public string state { set; get; }
        //public string country { set; get; }
        //public int phone { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                 new Hotel { id = 1, name = "AsyncInn1", streetAddress = "street a-1", city = "Amman", country = "Jordan", phone = 123, state = "#" },
                 new Hotel { id = 2, name = "AsyncInn2", streetAddress = "street a-2", city = "Irbid", country = "Jordan", phone = 789, state = "#" },
                 new Hotel { id = 3, name = "AsyncInn3", streetAddress = "street a-3", city = "Madaba", country = "Jordan", phone = 321, state = "#" });

            modelBuilder.Entity<Room>().HasData(
                   new Room { id = 1, name = "room1", layout = 1 },
                   new Room { id = 2, name = "room2", layout = 2 },
                   new Room { id = 3, name = "room3", layout = 3 });
          modelBuilder.Entity<Amenity>().HasData(
                 new Amenity { name = "amenity1", id = 1},
                 new Amenity { name = "amenity2", id = 2 },
                 new Amenity { name = "amenity3", id = 3 }
                 );

          modelBuilder.Entity<RoomAmenities>().HasKey(sc => new { sc.RoomId, sc.AmenityId });

        }
    }
}
