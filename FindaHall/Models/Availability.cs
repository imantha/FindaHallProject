using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindaHall.Models
{
    public class Availability
    {
        public string From_dt { get; set; }
        public string To_dt { get; set; }
        public string H_ID { get; set; }
        public List<BookingDetails> Bdetails { get; set; }
    }
}
