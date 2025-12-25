using Basket.API.ShoppingCarts.Shared.Validators;

namespace Basket.API.ShoppingCarts.SaveCart;

public class SaveCartRequestValidator : AbstractValidator<SaveCartRequest>
{
    public SaveCartRequestValidator()
    {
        RuleFor(x => x.AccountName)
            .ValidAccountName();
        
        When(x => x.CartItems.Count != 0, () =>
        {
            RuleForEach(x => x.CartItems).ChildRules(item =>
            {
                item.RuleFor(i => i.CatalogItemId)
                    .NotEmpty().WithMessage("CatalogItemId cannot be empty");
                
                item.RuleFor(i => i.Title)
                    .NotEmpty().WithMessage("ProductName cannot be empty");
                
                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than 0");
                
                item.RuleFor(i => i.UnitPrice)
                    .GreaterThan(0).WithMessage("UnitPrice must be greater than 0");
            });
        });
    }
}