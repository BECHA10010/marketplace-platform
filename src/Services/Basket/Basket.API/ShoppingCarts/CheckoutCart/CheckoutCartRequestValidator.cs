namespace Basket.API.ShoppingCarts.CheckoutCart;

public class CheckoutCartRequestValidator : AbstractValidator<CheckoutCartRequest>
{
    public CheckoutCartRequestValidator()
    {
        RuleFor(x => x.AccountName)
            .ValidAccountName();
    }
}