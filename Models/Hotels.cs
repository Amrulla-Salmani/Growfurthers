using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFurthers.Models
{
    public class Hotels
    {
        [Key]
        public int hotelId { get; set; }
        [Required]
        [MaxLength(100)]
        public string hotelName { get; set;}
        [Required]
        [MaxLength(500)]
        public string address { get; set;}
        [Required]
        [MaxLength(50)]
        public string city { get; set;}
        [Required]
        [MaxLength(15)]
        public string phoneNo { get; set; }
        public string email { get; set;}
        public string website { get; set; }
        public DateTime checkInTime { get; set; }
        public DateTime checkOutTime { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal rating { get; set; }
        public string imagePath { get; set; }
        [Required]
        [MaxLength(1)]
        public string active { get; set; }
    }
}
