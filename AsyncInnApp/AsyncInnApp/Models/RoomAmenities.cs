using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models
{
    public class RoomAmenities
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public Amenity Amenity { get; set; }
        public int AmenityId { get; set; }

    }
}
