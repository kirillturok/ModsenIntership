using MediatR;

namespace CqrsExample.CQRS.Queries.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<Product>;

