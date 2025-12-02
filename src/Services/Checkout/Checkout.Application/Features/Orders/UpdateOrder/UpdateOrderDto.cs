namespace Checkout.Application.Features.Orders.UpdateOrder;

public record UpdateOrderDto(
    ContactDto? ContactData,
    AddressDto? AddressData,
    PaymentMethod? PaymentMethod,
    CardDataDto? CardData
);