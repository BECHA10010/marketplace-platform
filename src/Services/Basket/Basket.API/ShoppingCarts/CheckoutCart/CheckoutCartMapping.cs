namespace Basket.API.ShoppingCarts.CheckoutCart;

public static class CheckoutCartMapping
{
    public static OrderSubmittedIntegrationEvent ToEvent(this CheckoutCartCommand command, ShoppingCartResultDto cart)
    {
        return new OrderSubmittedIntegrationEvent
        {
            CorrelationId = command.CorrelationId,
            AccountName = command.AccountName,
            Contact = new CustomerContactEventDto(command.Contact.FirstName, command.Contact.LastName, command.Contact.Email),
            Address = new CustomerAddressEventDto(command.Address.Street, command.Address.City),
            Payment = new PaymentDetailsEventDto(command.Payment.Method, command.Payment.CardNumber, command.Payment.Expiration, command.Payment.CvvCode),
            Items = cart.Items.Select(item => 
                new OrderItemEventDto(item.Title, item.Quantity, item.UnitPrice)
            ).ToImmutableArray()
        };
    }
    
    public static CheckoutCartCommand ToCommand(this CheckoutCartRequest request, Guid correlationId)
    {
        return new CheckoutCartCommand
        (
            correlationId,
            request.AccountName,
            new CustomerContactDto(request.Contact.FirstName, request.Contact.LastName, request.Contact.Email),
            new CustomerAddressDto(request.Address.Street, request.Address.City),
            new PaymentDetailsDto(request.Payment.Method, request.Payment.CardNumber, request.Payment.Expiration, request.Payment.CvvCode)
        );
    }

    public static CheckoutCartResponse ToResponse(this CheckoutCartResult result)
    {
        return new CheckoutCartResponse
        (
            result.CorrelationId,
            result.Removed ? "Удалено" : "Не удалено"
        );
    }
}