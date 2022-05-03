using AsyncInnApp.Data;
using AsyncInnApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using AsyncInnApp.Models.Interfaces;
using AsyncInnApp.Models.DTOs;

namespace AsyncInnApp.Models.Services
{
    public class HotelServices : IHotel
    {
        private readonly AsyncInnDbContext _context;

        public HotelServices(AsyncInnDbContext context)
        {
            _context = context;
        }

      
 
        public async Task<Hotel> Create (Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;

           await  _context.SaveChangesAsync();
            return hotel;

        }


        public async Task<HotelDTO> GetHotel(int id)
        {
            //Hotel hotel = await _context.Hotels.FindAsync(id);
            //return hotel;

            //return await _context.Hotels.Include(e => e.HotelRooms)
            //                            .ThenInclude(c => c.Room)
            //                            .FirstOrDefaultAsync(x => x.id == id);


            return await _context.Hotels.Select(hotel => new HotelDTO
            {
                ID = hotel.id ,
                Name = hotel.name,
                StreetAddress = hotel.streetAddress ,
                State = hotel.state,
                City = hotel.city,
                Phone = hotel.phone, 
                Rooms = hotel.HotelRooms
                .Select(item => new HotelRoomDTO
                {
                    HotelID = item.HotelId,
                    RoomID = item.RoomId,
                    RoomNumber = item.RoomNumber,
                    Rate = item.Rate,
                    PetFriendly = item.PetFriendly,
                    //RoomDTO =
                    //{
                    //   ID =  item.Room.id,
                    //   Name = item.Room.name,
                    //   Layout = item.Room.layout
                    //}


                }).ToList()
            }).FirstOrDefaultAsync(s => s.ID == id);

        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;


        }


        public async Task Delete(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task AddRoomToHotel(int roomId, int hotelId)
        {
            HotelRoom hotelRoom = new HotelRoom
            {
                RoomId = roomId,
                HotelId = hotelId
            };

            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        //public async Task RemoveRoomFromHotel(int roomId, int hotelId)
        //{
        //    HotelRoom hotelRoom = await GetHotelRoom();

        //    _context.Entry(hotelRoom).State = EntityState.Added;
        //    await _context.SaveChangesAsync();
        //}

        private Task<HotelRoom> GetHotelRoom()
        {
            throw new NotImplementedException();
        }
    }
}
