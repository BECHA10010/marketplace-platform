namespace Basket.API.Features.Commands.RemoveShoppingCart;

public static partial class RemoveShoppingCart
{
    public class Validator : AbstractValidator<RemoveShoppingCartCommand>
    {
        public Validator()
        {
            RuleFor(x => x.AccountName)
                .NotEmpty().WithMessage("AccountName cannot be empty")
                .MaximumLength(100).WithMessage("AccountName cannot be longer than 100 characters");
        }
    }
}