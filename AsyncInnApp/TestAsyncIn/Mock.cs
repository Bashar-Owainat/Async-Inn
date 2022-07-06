
using Microsoft.EntityFrameworkCore;
using AsyncInnApp.Data;
using Microsoft.Data.Sqlite;
using System;
using Xunit;
using AsyncInnApp.Models;
using System.Threading.Tasks;

namespace TestAsyncIn
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly AsyncInnDbContext _db;


        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseSqlServer(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Hotel> CreateAndSaveTestHotel()
        {
            var hotel = new Hotel { name = "Test", city = "Whatever" };
            _db.Hotels.Add(hotel);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, hotel.id); // Sanity check
            return hotel;
        }

        protected async Task<Room> CreateAndSaveTestRoom()
        {
            var room = new Room { name = "Test", layout = 2 };
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, room.id); // Sanity check
            return room;
        }

    }
}
