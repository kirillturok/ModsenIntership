using _3LayerExample.DTO;
using AutoMapper;
using Repository.Entities;

namespace _3LayerExample;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductForCreation, Product>();
    }
}
