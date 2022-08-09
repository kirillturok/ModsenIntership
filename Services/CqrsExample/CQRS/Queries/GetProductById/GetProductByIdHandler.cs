using CqrsExample.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsExample.CQRS.Queries.GetProductById;

public class GetProductByIdHandler
    : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly RepositoryContext _dbContext;

    public GetProductByIdHandler(RepositoryContext dbContext)
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
