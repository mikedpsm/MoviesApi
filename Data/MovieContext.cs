using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace MoviesApi.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
