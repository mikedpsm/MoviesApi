using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string StreetAddress { get; set; }
    public int AddressNumber { get; set; }
    public virtual Cinema Cinema { get; set; }
}
