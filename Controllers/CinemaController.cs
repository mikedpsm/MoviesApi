using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.DTOs;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public CinemaController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCinemaById), new { Id = cinema.Id }, cinemaDto);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> GetCinemas()
    {
        var cinemaList = _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
        return cinemaList;
    }

    [HttpGet("{id}")]
    public IActionResult GetCinemaById(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);    
        if(cinema is null) 
        {
            return NotFound();
        }
        ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema is null) 
        {
            return NotFound();
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema is null)
        {
            return NotFound();
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}
