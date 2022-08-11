using AutoMapper;
using CqrsExample.DTO;
using CqrsExample.Models;

namespace CqrsExample;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForRegistrationDto, User>();
    }
}
