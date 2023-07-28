using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.DTOs;

public class CreateSessionDto
{
    [Required]
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
}
