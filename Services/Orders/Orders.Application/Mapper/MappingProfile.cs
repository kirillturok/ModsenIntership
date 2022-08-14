using AutoMapper;
using Orders.Application.DTO;
using Orders.Domain.Models;

namespace Orders.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateOrderDto, Order>();
        CreateMap<UpdateOrderDto, Order>();
    }
}
