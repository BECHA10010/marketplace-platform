namespace Checkout.Application.Orders.Commands.RegisterOrder;

public class RegisterOrderCommandHandler(IOrderRepository repository)
    : ICommandHandler<RegisterOrderCommand>
{
    public async Task<Unit> Handle(RegisterOrderCommand command, CancellationToken cancellationToken)
    {
        var order = Order.Create(
            accountName: command.AccountName,
            contactInfo: new Contact(command.Contact.FirstName, command.Contact.LastName, command.Contact.Email),
            deliveryAddress: new DeliveryAddress(command.Address.Street, command.Address.City),
            paymentMethod: Enum.Parse<PaymentMethod>(command.PaymentMethod),
            cardDetails: command.Card is null
                ? null
                : new CreditCard(command.Card.CardNumber, command.Card.Expiration, command.Card.CvvCode),
            items: command.Items.Select(item => new OrderItem(item.Title, item.Quantity, item.UnitPrice)).ToList()
        );

        await repository.AddAsync(order, cancellationToken);
        
        return default;
    }
}