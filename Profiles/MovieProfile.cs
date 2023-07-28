using AutoMapper;
using MoviesApi.Data.DTOs;
using MoviesApi.Models;

namespace MoviesApi.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile() 
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie, ReadMovieDto>()
            .ForMember(movieDto => movieDto.Sessions,
                opt => opt.MapFrom(movie => movie.Sessions));
    }
}