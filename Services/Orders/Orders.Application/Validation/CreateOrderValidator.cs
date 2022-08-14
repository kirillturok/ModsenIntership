using FluentValidation;
using Products.Application.DTO;

namespace Products.Application.Validation;

public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    {
        RuleFor(order => order.Address)
                .NotEmpty();

        RuleFor(order => order.Products)
                .NotEmpty();

        RuleFor(order => order.Customer)
                .NotEmpty();
    }
}
