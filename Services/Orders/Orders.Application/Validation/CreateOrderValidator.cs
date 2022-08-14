using FluentValidation;
using Orders.Application.DTO;

namespace Orders.Application.Validation;

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
