using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;

namespace CqrsExample.CQRS.Queries.GetProducts;

public class GetProductsHandler
   : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly RepositoryContext _dbContext;

    public GetProductsHandler(RepositoryContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var notesQuery = await _dbContext.Products
            .ToListAsync(cancellationToken);

        return notesQuery;
    }
}
