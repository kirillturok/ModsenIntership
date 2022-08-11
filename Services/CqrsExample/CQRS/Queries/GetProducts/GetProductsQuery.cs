using MediatR;
using Repository.Entities;

namespace CqrsExample.CQRS.Queries.GetProducts;

public record GetProductsQuery : IRequest<IEnumerable<Product>>;
