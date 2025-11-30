namespace Checkout.Application.Features.Orders.UpdateOrder;

public class UpdateOrderHandler(IOrderRepository repository)
    : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
{
    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(command.OrderId);

        if (order is null)
            return new UpdateOrderResult(false);

        ApplyOrderChanges(order, command.UpdateData);
        
        await repository.UpdateAsync(order);

        return new UpdateOrderResult(true);
    }

    private static void ApplyOrderChanges(Order order, UpdateOrderDto updateOrderData)
    {
        var (contactData, addressData, paymentMethod, cardData) = updateOrderData;
        
        if (contactData is not null)
            order.ChangeCustomerContact(contactData.FirstName, contactData.LastName, contactData.Email);

        if (addressData is not null)
            order.ChangeDeliveryAddress(addressData.Street, addressData.City);

        if (paymentMethod.HasValue)
            order.ChangePaymentMethod(paymentMethod.Value);

        if (cardData is not null)
            order.ChangeCreditCard(cardData.CardNumber, cardData.Expiration, cardData.CvvCode);
    }
}