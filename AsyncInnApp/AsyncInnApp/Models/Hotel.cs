using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInnApp.Models
{
    public class Hotel
    {
       
        public int id { set; get; }
        public string name { set; get; }
        public string streetAddress { set; get; }
        public string city { set; get; }
        public string state { set; get; }
        public string country { set; get; }
        public int phone { set; get; }

        public List<HotelRoom> HotelRooms { get; set; }

    }
}
