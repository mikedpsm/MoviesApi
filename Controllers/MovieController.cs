using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.DTOs;
using MoviesApi.Models;
using System.Reflection;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{

    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adds a movie to the catalog
    /// </summary>
    /// <param name="movieDto">Object with the necessary fields for the creation of a movie.</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">If the insertion is successful</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(GetMovieById), 
            new { id = movie.Id}, 
            movie);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadMovieDto> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadMovieDto>>(
            _context.Movies.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id) 
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie is null) return NotFound();

        var movieDto = _mapper.Map<ReadMovieDto>(movie);

        return Ok(movieDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto updateMovieDto)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie is null) return NotFound();

        _mapper.Map(updateMovieDto, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult PatchMovie(int id, JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie is null) return NotFound();

        var movieToBePatched = _mapper.Map<UpdateMovieDto>(movie);
        patch.ApplyTo(movieToBePatched, ModelState);
        if(!TryValidateModel(movie))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(movieToBePatched, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie is null) return NotFound();

        _context.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }
}
