namespace Basket.API.ShoppingCarts.ClearCart;

public class ClearCartCommandValidator : AbstractValidator<ClearCartCommand>
{
    public ClearCartCommandValidator()
    {
        RuleFor(x => x.AccountName)
            .ValidAccountName();
    }
}