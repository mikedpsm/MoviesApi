using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("controller")]
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();
    private static int id = 0;

    [HttpPost]
    public void AddMovie([FromBody] Movie movie)
    {
        movie.Id = id++;
        movies.Add(movie);
        Console.WriteLine(movie.Title);
        Console.WriteLine(movie.Duration);
    }

    [HttpGet]
    public IEnumerable<Movie> GetAllMovies()
    {
        return movies;
    }

    [HttpGet]
    public Movie? GetMovieById(int id) 
    {
        return movies.FirstOrDefault(movie => movie.Id == id);
        
    }
}
