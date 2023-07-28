using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id {  get; set; }
    [Required(ErrorMessage = "Name field is mandatory")]
    public string Name { get; set; }
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }
}
