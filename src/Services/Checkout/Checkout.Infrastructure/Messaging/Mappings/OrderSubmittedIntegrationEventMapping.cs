namespace Checkout.Infrastructure.Messaging.Mappings;

public static class OrderSubmittedIntegrationEventMapping
{
    public static RegisterOrderCommand ToCommand(this OrderSubmittedIntegrationEvent orderSubmittedEvent)
    {
        var cardDetails = orderSubmittedEvent.Payment.CardNumber is not null
            ? new CardDetailsDto(
                orderSubmittedEvent.Payment.CardNumber, 
                orderSubmittedEvent.Payment.Expiration ?? "",
                orderSubmittedEvent.Payment.CvvCode ?? "")
            : null;
        
        return new RegisterOrderCommand(
            orderSubmittedEvent.CorrelationId,
            orderSubmittedEvent.AccountName,
            new CustomerContactDto(orderSubmittedEvent.Contact.FirstName, orderSubmittedEvent.Contact.LastName, orderSubmittedEvent.Contact.Email),
            new CustomerAddressDto(orderSubmittedEvent.Address.Street, orderSubmittedEvent.Address.City),
            orderSubmittedEvent.Payment.Method,
            cardDetails,
            orderSubmittedEvent.Items.Select(item => new OrderItemDto(item.Title, item.Quantity, item.UnitPrice)).ToImmutableArray()
        );
    }
}