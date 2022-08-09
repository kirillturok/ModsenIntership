using AutoMapper;
using MediatR;

namespace CqrsExample.CQRS.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly RepositoryContext _context;
    private readonly IMapper _mapper;

    public CreateProductHandler(RepositoryContext context, IMapper mapper) =>
        (_context, _mapper) = (context, mapper);

    public async Task<Product> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Product>(request);
        await _context.Products.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
