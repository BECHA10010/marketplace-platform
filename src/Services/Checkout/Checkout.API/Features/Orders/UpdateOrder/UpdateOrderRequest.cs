namespace Checkout.API.Features.Orders.UpdateOrder;

public record UpdateOrderRequest(
    ContactDataRequest? ContactData,
    AddressDataRequest? AddressData,
    string? PaymentMethod,
    CardDataRequest? CardData
);