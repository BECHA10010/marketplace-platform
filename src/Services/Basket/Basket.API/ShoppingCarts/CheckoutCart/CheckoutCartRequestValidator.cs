using Basket.API.ShoppingCarts.Shared.Validators;

namespace Basket.API.ShoppingCarts.CheckoutCart;

public class CheckoutCartRequestValidator : AbstractValidator<CheckoutCartRequest>
{
    public CheckoutCartRequestValidator()
    {
        RuleFor(x => x.AccountName)
            .ValidAccountName();
    }
}