using AsyncInnApp.Data;
using AsyncInnApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Services
{
    public class AmenityServices : IAmenity 
    {
        private readonly AsyncInnDbContext _context;

        public AmenityServices(AsyncInnDbContext context)
        {
            _context = context;
        }



        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return amenity;

        }


        public async Task<Amenity> GetAmenity(int id)
        {
            //Amenity amenity = await _context.Amenities.FindAsync(id);
            //return amenity;

            Amenity amenity = await _context.Amenities.FindAsync(id);

            var roomAmenity = await _context.RoomAmenities.Where(x => x.AmenityId == id)
                                                            .Include(x => x.Room)
                                                            .ToListAsync();
            return amenity;


           // return await _context.Amenities.Include(e => e.RoomAmenities).ThenInclude(c => c.Room).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;


        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;


        }


        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

       

    }
}
