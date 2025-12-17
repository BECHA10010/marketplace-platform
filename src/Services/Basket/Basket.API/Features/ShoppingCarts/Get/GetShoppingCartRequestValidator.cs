namespace Basket.API.Features.ShoppingCarts.Get;

public class GetShoppingCartRequestValidator : AbstractValidator<GetShoppingCartRequest>
{
    public GetShoppingCartRequestValidator()
    {
        RuleFor(x => x.AccountName)
            .ValidAccountName();
    }
}