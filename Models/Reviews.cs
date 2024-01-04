using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFurthers.Models
{
    public class Reviews
    {
        [Key]
        public int reviewId { get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public int hotelId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal? rating { get; set;}
        public string? comment { get; set; }
        public DateTime? reviewDate { get; set; }
        [Required]
        [MaxLength(1)]
        public string active { get; set; }
    }
}
