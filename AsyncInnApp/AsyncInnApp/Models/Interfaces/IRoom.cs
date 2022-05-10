using AsyncInnApp.Models;
using AsyncInnApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room room);
        Task<RoomDTO> GetRoom(int id);
        Task<List<Room>> GetRooms();
        Task<Room> UpdateRoom(int id, Room room);
        Task Delete(int id);

        Task AddAmenityToRoom(int amenityId, int roomId);
    }
}
