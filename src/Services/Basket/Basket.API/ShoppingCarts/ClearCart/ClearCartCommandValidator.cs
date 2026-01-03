using Basket.API.ShoppingCarts.Shared.Validators;

namespace Basket.API.ShoppingCarts.ClearCart;

public class ClearCartCommandValidator : AbstractValidator<ClearCartCommand>
{
    public ClearCartCommandValidator()
    {
        RuleFor(x => x.AccountName)
            .ValidAccountName();
    }
}