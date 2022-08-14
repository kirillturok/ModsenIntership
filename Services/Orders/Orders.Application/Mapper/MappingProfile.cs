using AutoMapper;
using Products.Application.DTO;
using Products.Domain.Models;

namespace Products.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateOrderDto, Order>();
        CreateMap<UpdateOrderDto, Order>();
    }
}
