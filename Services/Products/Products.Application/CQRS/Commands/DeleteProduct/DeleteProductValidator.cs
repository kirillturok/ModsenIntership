using FluentValidation;

namespace Products.Application.CQRS.Commands.DeleteProduct;

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(deleteProductCommand =>
            deleteProductCommand.Id).NotEmpty();
    }
}
