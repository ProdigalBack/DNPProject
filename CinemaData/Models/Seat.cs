
using System.ComponentModel.DataAnnotations;

namespace CinemaData.Models
{
    public class Seat
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 6)]
        public int Row { get; set; }

        [Required]
        [Range(1, 8)]
        public int Column { get; set; }

    }
}
