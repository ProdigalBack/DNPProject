
using System.ComponentModel.DataAnnotations;

namespace CinemaData.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public ShowingSeat ShowingSeat { get; set; }

        [Required]
        public User User { get; set; }
    }
}
