using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Domain.Models;
using Products.Repository.Context;

namespace Products.Application.CQRS.Queries.GetProducts;

public class GetProductsHandler
   : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly ProductsContext _dbContext;

    public GetProductsHandler(ProductsContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var notesQuery = await _dbContext.Products
            .ToListAsync(cancellationToken);

        return notesQuery;
    }
}
