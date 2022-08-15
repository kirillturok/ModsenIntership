using FluentValidation;
using Products.Application.CQRS.Commands.CreateCommand;

namespace Products.Application.Validation;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(createProductCommand =>
            createProductCommand.Name).NotEmpty().MaximumLength(250);
    }
}
