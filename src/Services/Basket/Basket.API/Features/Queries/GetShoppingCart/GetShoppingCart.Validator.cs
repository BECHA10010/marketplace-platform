namespace Basket.API.Features.Queries.GetShoppingCart;

public static partial class GetShoppingCart
{
    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            RuleFor(x => x.AccountName)
                .NotEmpty().WithMessage("AccountName cannot be empty")
                .MaximumLength(100).WithMessage("AccountName cannot be longer than 100 characters");
        }
    }
}