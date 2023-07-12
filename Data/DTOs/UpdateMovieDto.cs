using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.DTOs;

public class UpdateMovieDto 
{
    [Required(ErrorMessage = "Movie title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Movie genre is required")]
    [StringLength(50, ErrorMessage = "Movie genre may not exceed 50 chars")]
    public string Genre { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "Duration must be between 70 and 600 minutes")]
    public int Duration { get; set; }
}
