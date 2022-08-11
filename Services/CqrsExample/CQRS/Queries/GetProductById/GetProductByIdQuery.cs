using MediatR;
using Repository.Entities;

namespace CqrsExample.CQRS.Queries.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<Product>;

