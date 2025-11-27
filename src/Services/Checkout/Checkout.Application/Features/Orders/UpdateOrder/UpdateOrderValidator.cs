namespace Checkout.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId cannot be empty")
            .Must(arg => Guid.TryParse(arg, out _)).WithMessage("OrderId must be a valid GUID");
    }
}