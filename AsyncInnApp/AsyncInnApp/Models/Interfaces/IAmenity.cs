using AsyncInnApp.Models;
using AsyncInnApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> Create(Amenity amenity);
        Task<AmenityDTO> GetAmenity(int id);
        Task<List<Amenity>> GetAmenities();
        Task<Amenity> UpdateAmenity(int id, Amenity amenity);
        Task Delete(int id);
    }
}
