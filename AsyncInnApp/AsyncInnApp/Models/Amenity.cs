using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models
{
    public class Amenity
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<RoomAmenities> RoomAmenities { get; set; }

    }
}
