using MediatR;

namespace CqrsExample.CQRS.Commands.CreateProduct;

public record CreateProductCommand(string Name) : IRequest<Product>;
