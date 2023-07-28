using AutoMapper;
using MoviesApi.Data.DTOs;
using MoviesApi.Models;

namespace MoviesApi.Profiles;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<CreateSessionDto, Session>();
        CreateMap<Session, ReadAddressDto>();
    }
}
