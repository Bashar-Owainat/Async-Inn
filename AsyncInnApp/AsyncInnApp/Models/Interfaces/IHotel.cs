using AsyncInnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Interfaces
{
    public interface IHotel
    {
        Task<Hotel> Create(Hotel hotel);
        Task<List<Hotel>> GetStudents();
        Task<Hotel> GetStudent(int id);
        Task<Hotel> UpdateStudent(int id, Hotel hotel);
        Task Delete(int id);
    }
}
