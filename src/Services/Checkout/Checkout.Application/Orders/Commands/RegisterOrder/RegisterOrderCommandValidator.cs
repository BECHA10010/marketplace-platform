namespace Checkout.Application.Orders.Commands.RegisterOrder;

public class RegisterOrderCommandValidator : AbstractValidator<RegisterOrderCommand>
{
    public RegisterOrderCommandValidator()
    {
        RuleFor(x => x.AccountName).NotEmpty().Length(3, 20);

        RuleFor(x => x.Contact).NotNull();
        
        RuleFor(x => x.Contact.FirstName).NotEmpty();
        RuleFor(x => x.Contact.LastName).NotEmpty();
        RuleFor(x => x.Contact.Email).NotEmpty().EmailAddress();
        
        RuleFor(x => x.Address).NotNull();
        
        RuleFor(x => x.Address.Street).NotEmpty();
        RuleFor(x => x.Address.City).NotEmpty();
        
        RuleFor(x => x.PaymentMethod)
            .NotEmpty()
            .Must(arg => Enum.TryParse<PaymentMethod>(arg, out _)).WithMessage("Invalid Payment Method");

        When(x => Enum.TryParse<PaymentMethod>(x.PaymentMethod, out var method) 
                  && method == PaymentMethod.CreditCard, () =>
        {
            RuleFor(x => x.Card)
                .NotNull()
                .DependentRules(() =>
                {
                    RuleFor(x => x.Card!.CardNumber).NotEmpty();
                    RuleFor(x => x.Card!.Expiration).NotEmpty();
                    RuleFor(x => x.Card!.CvvCode).NotEmpty();
                });
        });
        
        RuleFor(x => x.Items).NotEmpty();
        
        RuleForEach(x => x.Items)
            .ChildRules(i =>
            {
                i.RuleFor(x => x.Title).NotEmpty();
                i.RuleFor(x => x.Quantity).GreaterThan(0);
                i.RuleFor(x => x.UnitPrice).GreaterThan(0);
            });
    }
}