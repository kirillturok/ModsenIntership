using FluentValidation;
using Orders.Application.DTO;

namespace Orders.Application.Validation;

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
