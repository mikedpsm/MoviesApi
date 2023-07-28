using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.DTOs;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private MovieContext _movieContext;
    private IMapper _mapper;

    public AddressController(MovieContext movieContext, IMapper mapper)
    {
        _movieContext = movieContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddAddress([FromBody] CreateAddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        _movieContext.Addresses.Add(address);
        _movieContext.SaveChanges();
        return CreatedAtAction(nameof(GetAddressById), new { Id =  address.Id }, address);
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAddresses()
    {
        return _mapper.Map<List<ReadAddressDto>>(_movieContext.Addresses);
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        Address address = _movieContext.Addresses.FirstOrDefault(x => x.Id == id);
        if (address is null) 
        {
            return NotFound();
        }
        ReadAddressDto addressDto = _mapper.Map<ReadAddressDto>(address);
        return Ok(addressDto);
    }

    [HttpPut]
    public IActionResult PutAddress(int id, [FromBody] UpdateAddressDto addressDto)
    {
        Address address = _movieContext.Addresses.FirstOrDefault(a => a.Id == id);
        if (address is null)
        {
            return NotFound();
        }
        _mapper.Map(addressDto, address);
        _movieContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        Address address = _movieContext.Addresses.FirstOrDefault(x => x.Id == id);
        if (address == null)
        {
            return NotFound();
        }
        _movieContext.Remove(address);
        _movieContext.SaveChanges();
        return NoContent();
    }
}
