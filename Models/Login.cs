using System.ComponentModel.DataAnnotations;

namespace GrowFurthers.Models
{
    public class Login
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(10)]
        public string Password { get; set; }
    }
}
