using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.DTOs;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private IMapper _mapper;
    private MovieContext _context;

    public SessionController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddSession([FromBody] CreateSessionDto sessionDto)
    {
        Session session = _mapper.Map<Session>(sessionDto);
        _context.Sessions.Add(session);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetSessionById), new { Id = session.Id }, session);
    }

    [HttpGet]
    public IEnumerable<ReadSessionDto> GetSessions()
    {
        return _mapper.Map<List<ReadSessionDto>>(_context.Sessions);
    }

    [HttpGet("{id}")]
    public IActionResult GetSessionById(int id)
    {
        Session session = _context.Sessions.FirstOrDefault(x => x.Id == id);
        if (session is null)
        {
            return NotFound();
        }
        ReadSessionDto sessionDto = _mapper.Map<ReadSessionDto>(session);
        return Ok(sessionDto);
    }
}
