using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Movie
{

    public int Id { get; set; }
    [Required(ErrorMessage = "Movie title is required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Movie genre is required")]
    [MaxLength(50, ErrorMessage = "Movie genre may not exceed 50 chars")]
    public string Genre { get; set; }
    [Required]
    [Range(70, 600, ErrorMessage = "Duration must be between 70 and 600 minutes")]
    public int Duration { get; set; }
}
