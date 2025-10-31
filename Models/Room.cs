using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCafe.Models
{
    public class Room
    {
        public string Name { get; set; }
        public List<BookedDate> BookedDates { get; set; }
        public int Interval { get; set; }
    }

    public class BookedDate
    {
        public string Date { get; set; }
        public List<BookedHour> BookedHours { get; set; }
    }

    public class BookedHour
    {
        public string BookingReference { get; set; }
        public string Hour { get; set; }
    }
}
