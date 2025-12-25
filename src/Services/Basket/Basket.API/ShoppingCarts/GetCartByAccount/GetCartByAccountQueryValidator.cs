using Basket.API.ShoppingCarts.Shared.Validators;

namespace Basket.API.ShoppingCarts.GetCartByAccount;

public class GetCartByAccountQueryValidator : AbstractValidator<GetCartByAccountQuery>
{
    public GetCartByAccountQueryValidator()
    {
        RuleFor(x => x.AccountName)
            .ValidAccountName();
    }
}