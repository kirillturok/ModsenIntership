using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Exceptions;
using Products.Domain.Models;
using Products.Repository.Context;

namespace Products.Application.CQRS.Queries.GetProductById;

public class GetProductByIdHandler
    : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly ProductsContext _dbContext;

    public GetProductByIdHandler(ProductsContext dbContext)
        => _dbContext = dbContext;

    public async Task<Product> Handle(GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(note =>
            note.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        return entity;
    }
}
