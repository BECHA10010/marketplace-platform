namespace Checkout.Application.Features.Orders.CreateOrder;

public record CreateOrderDto(    
    string AccountName,
    ContactDto ContactInfo,
    AddressDto DeliveryAddress,
    PaymentMethod PaymentMethod,
    CardDataDto? CardDetails,
    List<OrderItemDto> Items
);