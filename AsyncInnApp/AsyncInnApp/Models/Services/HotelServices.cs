using AsyncInnApp.Data;
using AsyncInnApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;


namespace AsyncInnApp.Models.Services
{
    public class HotelServices 
    {
        private readonly AsyncInnDbContext _context;

        public HotelServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

       

    }
}
