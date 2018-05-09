
using System.ComponentModel.DataAnnotations;

namespace CinemaData.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(12)]
        public string Password { get; set; }

        
    }
}
