using MediatR;

namespace Products.Application.CQRS.Commands.DeleteCommand;

public record DeleteProductCommand(Guid Id) : IRequest;
