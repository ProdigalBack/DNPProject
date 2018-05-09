using System;
using System.ComponentModel.DataAnnotations;


namespace CinemaData.Models
{
     public class Showing
    {
        public int Id { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public DateTime Showtime { get; set; }
    }
}
