namespace Checkout.Application.Features.Orders.CreateOrder;

public class CreateOrderHandler(IOrderRepository repository) 
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderData = command.OrderData;
        
        var order = Order.Create(
            accountName: orderData.AccountName,
            contactInfo: new Contact(orderData.ContactInfo.FirstName, orderData.ContactInfo.LastName, orderData.ContactInfo.Email),
            deliveryAddress: new DeliveryAddress(orderData.DeliveryAddress.Street, orderData.DeliveryAddress.City),
            paymentMethod: orderData.PaymentMethod,
            cardDetails: orderData.CardDetails is not null 
                ? new CreditCard(orderData.CardDetails.CardNumber, orderData.CardDetails.Expiration, orderData.CardDetails.CvvCode)
                : null,
            items: orderData.Items.Select(i => new OrderItem(i.CatalogItemName, i.Quantity, i.UnitPrice)).ToList());
        
        await repository.AddAsync(order);

        return new CreateOrderResult(order.Id, "Order success created");
    }
}