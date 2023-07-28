namespace MoviesApi.Data.DTOs;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ReadAddressDto Address { get; set; }
    public ICollection<ReadSessionDto> Sessions { get; set; }
}
