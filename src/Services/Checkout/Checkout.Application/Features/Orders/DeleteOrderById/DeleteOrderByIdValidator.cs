namespace Checkout.Application.Orders.Commands.DeleteOrderById;

public class DeleteOrderByIdValidator : AbstractValidator<DeleteOrderByIdCommand>
{
    public DeleteOrderByIdValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId cannot be empty")
            .Must(arg => Guid.TryParse(arg, out _)).WithMessage("OrderId must be a valid GUID");
    }
}