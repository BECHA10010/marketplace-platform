namespace Checkout.Application.Orders.Commands.CreateOrder.DTOs;

public record CreateOrderDto(    
    string AccountName,
    ContactDto ContactInfo,
    AddressDto DeliveryAddress,
    PaymentMethod PaymentMethod,
    CardDetailsDto? CardDetails,
    decimal TotalPrice,
    List<OrderItemDto> Items
);