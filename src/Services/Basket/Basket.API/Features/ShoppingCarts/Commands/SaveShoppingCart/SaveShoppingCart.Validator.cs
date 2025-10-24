namespace Basket.API.Features.ShoppingCarts.Commands.SaveShoppingCart;

public static partial class SaveShoppingCart
{
    public class Validator : AbstractValidator<SaveShoppingCartCommand>
    {
        public Validator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("ShoppingCart cannot be null");
            
            RuleFor(x => x.Cart.AccountName)
                .NotEmpty().WithMessage("AccountName cannot be empty")
                .MaximumLength(100).WithMessage("AccountName cannot be longer than 100 characters");
            
            RuleFor(x => x.Cart.Items).NotEmpty().WithMessage("ShoppingCart must contain at least one item");
            
            RuleForEach(x => x.Cart.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.Id)
                    .NotEqual(Guid.Empty).WithMessage("ItemId cannot be not Guid");
                
                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("ItemQuantity must be greater than 0");
                
                item.RuleFor(i => i.Price)
                    .GreaterThan(0).WithMessage("ItemPrice must be greater than 0");
                
                item.RuleFor(i => i.Title)
                    .NotEmpty().WithMessage("ItemTitle cannot be empty");
            });
        }
    }
}