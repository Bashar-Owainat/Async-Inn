using AsyncInnApp.Models;
using AsyncInnApp.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestAsyncIn
{
   public class HotelTests : Mock
    {

        protected async Task<Hotel> CreateAndSaveTestHotel()
        {
            var hotel = new Hotel { name = "test", id = 1 };
            _db.Hotels.Add(hotel);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, hotel.id); // Sanity check
            return hotel;
        }
        [Fact]
        public async void TestUpdatingHotel()
        {
            Hotel hotel = (Hotel)CreateAndSaveTestHotel().Result;
            string OldHotelName = hotel.name;
            hotel.name = "updated test value";
            var HotelService = new HotelServices(_db);
           

            hotel = await HotelServices.UpdateHotel(hotel.id, hotel);
            hotel = HotelServices.GetHotel(hotel.id).Result;
            Assert.NotEqual(OldHotelName, hotel.name);
        }


        [Fact]
        public async void TestAddingRoomToHotel()
        {
            Hotel hotel = (Hotel)CreateAndSaveTestHotel().Result;
            Room room = (Room)CreateAndSaveTestRoom().Result;
            var HotelService = new HotelServices(_db);

            await HotelService.AddRoomToHotel( room.id, hotel.id);
            hotel = (await HotelService.GetHotel(hotel.id)).Result;

            Assert.Contains(hotel.HotelRooms, e => e.RoomId == room.id);
        }
    }
}
