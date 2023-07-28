using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.DTOs;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "Name field is mandatory")]
    public string Name { get; set; }
    public int AddressId { get; set; }
}
