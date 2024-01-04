using System.ComponentModel.DataAnnotations;

namespace GrowFurthers.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(10)]
        public string Password { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MaxLength(15)]
        public string phoneNo { get; set; }
        public DateTime memberSince { get; set; }
        public string? membership { get; set; }
        [MaxLength(50)]
        public string? userRole { get; set; }
        [MaxLength(1)]
        public string? active { get; set; }

    }
}
