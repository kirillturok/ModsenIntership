using AutoMapper;
using Products.Application.CQRS.Commands.CreateProduct;
using Products.Domain.Models;

namespace Products.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
