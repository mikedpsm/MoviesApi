using AutoMapper;
using MoviesApi.Data.DTOs;
using MoviesApi.Models;

namespace MoviesApi.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<Address, ReadAddressDto>();
        CreateMap<UpdateAddressDto, Address>();
    }
}
