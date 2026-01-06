namespace Checkout.Application.Orders.DTOs;

public record OrderDto(
    Guid Id,
    string AccountName,
    decimal TotalAmount,
    string Status,
    CustomerAddressDto Address,
    string PaymentMethod,
    string PaymentStatus,
    List<OrderItemDto> Items
);