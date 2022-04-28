using AsyncInnApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models.Interfaces
{
    public interface IHotel
    {
        Task<Hotel> Create(Hotel hotel);
        Task<HotelDTO> GetHotel(int id);
        Task<List<Hotel>> GetHotels();
        Task<Hotel> UpdateHotel(int id, Hotel hotel);
        Task Delete(int id);
        Task AddRoomToHotel(int roomId, int hotelId);

    }
}
