using AutoMapper;
using Identity.DTO;
using Identity.Models;

namespace Identity
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
