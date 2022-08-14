using AutoMapper;
using MediatR;
using Products.Domain.Models;
using Products.Repository.Context;

namespace Products.Application.CQRS.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly ProductsContext _context;
    private readonly IMapper _mapper;

    public CreateProductHandler(ProductsContext context, IMapper mapper) =>
        (_context, _mapper) = (context, mapper);

    public async Task<Product> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Product>(request);
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
