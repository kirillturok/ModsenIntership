using FluentValidation;
using Products.Application.CQRS.Commands.UpdateCommand;

namespace Products.Application.Validation
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(updateProductCommand =>
                updateProductCommand.product.Id).NotEmpty();
            RuleFor(updateProductCommand =>
                updateProductCommand.product.Name).NotEmpty().MaximumLength(250);
        }
    }
}
