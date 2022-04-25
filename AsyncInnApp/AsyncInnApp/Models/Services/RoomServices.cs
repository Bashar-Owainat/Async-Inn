using AsyncInnApp.Data;
using AsyncInnApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Services
{
    public class RoomServices : IRoom
    {
        private readonly AsyncInnDbContext _context;

        public RoomServices(AsyncInnDbContext context)
        {
            _context = context;
        }



        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return room;

        }


        public async Task<Room> GetRoom(int id)
        {
            //Room room = await _context.Rooms.FindAsync(id);
            //return room;

            return await _context.Rooms.Include(e => e.RoomAmenities)
                                          .ThenInclude(c => c.Amenity)
                                          .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;


        }


        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task AddAmenityToRoom( int roomId, int amenityId)
        {
            RoomAmenities roomAmenities = new RoomAmenities
            {
                RoomId = roomId,
                AmenityId = amenityId

            };

            _context.Entry(roomAmenities).State = EntityState.Added;
            await _context.SaveChangesAsync();

        }



    }
}
