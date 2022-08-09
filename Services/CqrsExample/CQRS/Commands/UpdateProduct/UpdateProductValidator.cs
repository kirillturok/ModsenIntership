using FluentValidation;

namespace CqrsExample.CQRS.Commands.UpdateProduct
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
