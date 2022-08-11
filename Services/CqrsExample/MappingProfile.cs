using AutoMapper;
using CqrsExample.CQRS.Commands.CreateProduct;
using Repository.Entities;

namespace CqrsExample
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
