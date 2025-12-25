namespace Checkout.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderDto(
    ContactDto? ContactData,
    AddressDto? AddressData,
    PaymentMethod? PaymentMethod,
    CardDataDto? CardData
);