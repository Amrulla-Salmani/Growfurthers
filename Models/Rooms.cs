using System.ComponentModel.DataAnnotations;

namespace GrowFurthers.Models
{
    public class Rooms
    {
        public Hotels Hotels { get; set; }
        [Key]
        public int roomId { get; set; }
        [Required]
        public int hotelId { get; set; }
        [Required]
        public int roomNumber { get; set; }
        [Required]
        public string roomType { get; set; }
        [Required]
        public int pricePerNight { get; set; }
        [Required]
        [MaxLength(1)]
        public string active { get; set; }
    }
}
