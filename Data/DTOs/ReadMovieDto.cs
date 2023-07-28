using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.DTOs;

public class ReadMovieDto 
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public DateTime ConsultingTime { get; set; } = DateTime.Now;
    public ICollection<ReadSessionDto> Sessions { get; set; }
}
