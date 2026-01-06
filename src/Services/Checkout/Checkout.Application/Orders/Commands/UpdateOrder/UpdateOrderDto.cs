namespace Checkout.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderDto(
    CustomerContactDto? ContactData,
    CustomerAddressDto? AddressData,
    PaymentMethod? PaymentMethod,
    CardDetailsDto? CardData
);