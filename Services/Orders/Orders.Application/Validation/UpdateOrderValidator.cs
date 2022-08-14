using FluentValidation;
using Products.Application.DTO;

namespace Products.Application.Validation;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderValidator()
    {
        RuleFor(order => order.Id)
                .NotEmpty();

        RuleFor(order => order.Address)
                .NotEmpty();

        RuleFor(order => order.Products)
                .NotNull();
    }
}
