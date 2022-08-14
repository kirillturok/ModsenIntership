using MediatR;

namespace Products.Application.CQRS.Commands.DeleteProduct;

public record DeleteProductCommand(Guid Id) : IRequest;
