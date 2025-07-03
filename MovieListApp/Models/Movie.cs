using System.ComponentModel.DataAnnotations;

namespace MovieListApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
    }
}
