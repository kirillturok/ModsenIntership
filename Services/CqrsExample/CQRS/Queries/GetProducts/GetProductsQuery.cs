using MediatR;

namespace CqrsExample.CQRS.Queries.GetProducts;

public record GetProductsQuery : IRequest<IEnumerable<Product>>;
