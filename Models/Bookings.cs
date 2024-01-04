using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFurthers.Models
{
    public class Bookings
    {
        [Key]
        public int bookingId { get; set; }
        public int hotelId { get; set;}
        public string guestName { get; set;}
        public DateTime checkInDate { get; set;}
        public DateTime checkOutDate { get; set;}
        public int numAdults { get; set;}
        public int numChildren { get; set; }
        public string bookingStatus { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal totalAmt { get; set; }
        public string paymentStatus { get; set; }
        public string active { get; set; }
    }
}
