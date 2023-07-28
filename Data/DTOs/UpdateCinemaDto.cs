using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.DTOs;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "Name field is mandatory")]
    public string Name { get; set; }
}
