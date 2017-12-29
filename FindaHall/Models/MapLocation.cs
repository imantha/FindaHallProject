using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindaHall.Models
{
    public class MapLocation
    {
        public string H_ID { get; set; }
        public string Name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public int Price { get; set; }
    }
}
