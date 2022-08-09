using MediatR;

namespace CqrsExample.CQRS.Commands.UpdateProduct;

public record UpdateProductCommand(Product product) : IRequest;
