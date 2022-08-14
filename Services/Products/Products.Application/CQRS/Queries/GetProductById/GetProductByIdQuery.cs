using MediatR;
using Products.Domain.Models;

namespace Products.Application.CQRS.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<Product>;

