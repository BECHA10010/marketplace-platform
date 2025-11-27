namespace Checkout.API.Features.Orders.DeleteOrderById;

public class DeleteOrderByIdRequestValidator : AbstractValidator<DeleteOrderByIdRequest>
{
    public DeleteOrderByIdRequestValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId cannot be empty")
            .Must(arg => Guid.TryParse(arg, out _)).WithMessage("OrderId must be a valid GUID");
    }
}