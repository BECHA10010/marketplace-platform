namespace Basket.API.Features.ShoppingCarts.Clear;

public class ClearShoppingCartRequestValidator : AbstractValidator<ClearShoppingCartRequest>
{
    public ClearShoppingCartRequestValidator()
    {
        RuleFor(x => x.AccountName)
            .ValidAccountName();
    }
}