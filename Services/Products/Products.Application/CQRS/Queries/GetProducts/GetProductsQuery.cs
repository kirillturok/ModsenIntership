using MediatR;
using Products.Domain.Models;

namespace Products.Application.CQRS.Queries.GetProducts;

public record GetProductsQuery : IRequest<IEnumerable<Product>>;
