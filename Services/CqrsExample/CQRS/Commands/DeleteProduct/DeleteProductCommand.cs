using MediatR;

namespace CqrsExample.CQRS.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest;
