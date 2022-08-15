using FluentValidation;
using Products.Application.CQRS.Commands.DeleteCommand;

namespace Products.Application.Validation;

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(deleteProductCommand =>
            deleteProductCommand.Id).NotEmpty();
    }
}
