using FluentValidation;

namespace CqrsExample.CQRS.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(createProductCommand =>
            createProductCommand.Name).NotEmpty().MaximumLength(250);
    }
}
