using FluentValidation;

namespace CqrsExample.CQRS.Queries.GetProductById;

public class DeleteProductValidator : AbstractValidator<GetProductByIdQuery>
{
    public DeleteProductValidator()
    {
        RuleFor(getProductByIdQuery =>
            getProductByIdQuery.Id).NotEmpty();
    }
}
