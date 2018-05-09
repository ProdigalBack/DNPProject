
using System.ComponentModel.DataAnnotations;

namespace CinemaData.Models
{
    public class ShowingSeat
    {
        public int Id { get; set; }

        [Required]
        public Showing Showing { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public Seat Seat { get; set; }

    }
}
