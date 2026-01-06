namespace Basket.API.ShoppingCarts.Shared.Validators;

public static class AccountNameValidationExtensions
{
    public static IRuleBuilderOptions<T, string> ValidAccountName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Account name is required")
            .NotNull().WithMessage("Account name cannot be null")
            .MinimumLength(3).WithMessage("Account name must be at least 3 characters long")
            .MaximumLength(20).WithMessage("Account name cannot exceed 20 characters")
            .Matches("^[a-zA-Z0-9_@.-]+$")
            .WithMessage("Account name can only contain letters, numbers, and _ @ . -");
    }
}