using FluentValidation;

namespace Products.Application.CQRS.Queries.GetProductById;

public class DeleteProductValidator : AbstractValidator<GetProductByIdQuery>
{
    public DeleteProductValidator()
    {
        RuleFor(getProductByIdQuery =>
            getProductByIdQuery.Id).NotEmpty();
    }
}
