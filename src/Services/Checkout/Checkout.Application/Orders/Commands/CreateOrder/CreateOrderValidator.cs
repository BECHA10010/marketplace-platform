namespace Checkout.Application.Orders.Commands.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.OrderData).NotNull();
        
        RuleFor(x => x.OrderData.AccountName).NotNull().Length(3, 20);

        RuleFor(x => x.OrderData.Items).NotEmpty();

        RuleForEach(x => x.OrderData.Items)
            .ChildRules(i =>
            {
                i.RuleFor(x => x.Quantity).GreaterThan(0);
                i.RuleFor(x => x.UnitPrice).GreaterThan(0);
            });

        When(x => x.OrderData.PaymentMethod == PaymentMethod.CreditCard, () =>
        {
            RuleFor(x => x.OrderData.CardDetails).NotNull();
        });
    }
}