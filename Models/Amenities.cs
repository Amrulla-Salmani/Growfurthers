using System.ComponentModel.DataAnnotations;

namespace GrowFurthers.Models
{
    public class Amenities
    {
        [Key]
        public int amenityId { get; set; }
        [Required]
        public int hotelId { get; set; }

        [Required]
        [MaxLength(50)]
        public string amenityName { get; set; }

        [MaxLength(500)]
        public string description { get; set; }

        [Required]
        [MaxLength(50)]
        public string status { get; set; }

        [Required]
        [MaxLength(1)]
        public string active { get; set; }

    }
}
