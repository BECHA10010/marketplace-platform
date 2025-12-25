using Checkout.Domain.Order;

namespace Checkout.API.Orders.UpdateOrder;

public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderRequestValidator()
    {
        RuleFor(x => x.PaymentMethod)
            .Must(x => Enum.TryParse<PaymentMethod>(x, out _))
            .When(x => !string.IsNullOrEmpty(x.PaymentMethod))
            .WithMessage("Payment Method must be a valid PaymentMethod");

        When(x => Enum.TryParse<PaymentMethod>(x.PaymentMethod, out var method) 
                  && method == PaymentMethod.CreditCard, () =>
        {
            RuleFor(x => x.CardData)
                .NotNull().WithMessage("Card data is required when payment method is Card");
        });
    }
}