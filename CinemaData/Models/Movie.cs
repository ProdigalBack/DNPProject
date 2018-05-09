using System.ComponentModel.DataAnnotations;


namespace CinemaData.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]  
        public string Name { get; set; }

        [Required]
        [Range(70,180)]
        public int Runtime { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Director { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Actor { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
