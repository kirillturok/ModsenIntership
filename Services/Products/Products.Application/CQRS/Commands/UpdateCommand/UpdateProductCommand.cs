using MediatR;
using Products.Domain.Models;

namespace Products.Application.CQRS.Commands.UpdateCommand;

public record UpdateProductCommand(Product product) : IRequest;
