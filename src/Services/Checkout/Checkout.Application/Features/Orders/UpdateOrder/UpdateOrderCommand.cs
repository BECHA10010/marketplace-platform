namespace Checkout.Application.Features.Orders.UpdateOrder;

public record UpdateOrderCommand(Guid OrderId, UpdateOrderDto UpdateData) : ICommand<UpdateOrderResult>;

public record UpdateOrderDto(
    ContactDto? ContactData,
    AddressDto? AddressData,
    PaymentMethod? PaymentMethod,
    CardDataDto? CardData
);