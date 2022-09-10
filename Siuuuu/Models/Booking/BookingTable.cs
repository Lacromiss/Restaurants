using System.Collections.Generic;

namespace Siuuuu.Models.Booking
{
    public class BookingTable
    {
        public int Id { get; set; }
        public int Masaa { get; set; }
        public List< Booking> Bookings { get; set; }
    }
}
