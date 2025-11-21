namespace Checkout.Application.Orders.Commands.CreateOrder.DTOs;

public record CreateOrderDto(    
    string AccountName,
    ContactDto ContactInfo,
    AddressDto DeliveryAddress,
    PaymentMethod PaymentMethod,
    CreateOrderCardDetailsDto? CardDetails,
    decimal TotalPrice,
    List<OrderItemDto> Items
);