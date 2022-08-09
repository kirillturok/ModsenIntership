using AutoMapper;
using CqrsExample.CQRS.Commands.CreateProduct;

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
