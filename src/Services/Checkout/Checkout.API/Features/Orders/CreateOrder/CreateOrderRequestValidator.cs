namespace Checkout.API.Features.Orders.CreateOrder;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.AccountName).NotEmpty().Length(3, 20);

        RuleFor(x => x.ContactData).NotNull();
        
        RuleFor(x => x.ContactData.FirstName).NotEmpty();
        RuleFor(x => x.ContactData.LastName).NotEmpty();
        RuleFor(x => x.ContactData.Email).NotEmpty().EmailAddress();
        
        RuleFor(x => x.AddressData).NotNull();
        
        RuleFor(x => x.AddressData.Street).NotEmpty();
        RuleFor(x => x.AddressData.City).NotEmpty();
        
        RuleFor(x => x.PaymentMethod)
            .NotEmpty()
            .Must(arg => Enum.TryParse<PaymentMethod>(arg, out _)).WithMessage("Invalid Payment Method");

        When(x => Enum.TryParse<PaymentMethod>(x.PaymentMethod, out var method) 
                  && method == PaymentMethod.CreditCard, () =>
        {
            RuleFor(x => x.CardData)
                .NotNull()
                .DependentRules(() =>
                {
                    RuleFor(x => x.CardData!.CardNumber).NotEmpty();
                    RuleFor(x => x.CardData!.Expiration).NotEmpty();
                    RuleFor(x => x.CardData!.CvvCode).NotEmpty();
                });
        });
        
        RuleFor(x => x.Items).NotEmpty();
        
        RuleForEach(x => x.Items)
            .ChildRules(i =>
            {
                i.RuleFor(x => x.CatalogItemName).NotEmpty();
                i.RuleFor(x => x.Quantity).GreaterThan(0);
                i.RuleFor(x => x.UnitPrice).GreaterThan(0);
            });
    }
}