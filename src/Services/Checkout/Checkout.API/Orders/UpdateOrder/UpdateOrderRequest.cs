using Checkout.API.Orders.Common.Requests;

namespace Checkout.API.Orders.UpdateOrder;

public record UpdateOrderRequest(
    ContactDataRequest? ContactData,
    AddressDataRequest? AddressData,
    string? PaymentMethod,
    CardDataRequest? CardData
);