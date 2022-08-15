using MediatR;
using Products.Domain.Models;

namespace Products.Application.CQRS.Commands.CreateCommand;

public record CreateProductCommand(string Name) : IRequest<Product>;
