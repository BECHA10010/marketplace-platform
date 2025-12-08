namespace Checkout.Application.Features.Orders.Common.DTOs;

public record OrderDto(
    Guid Id,
    string AccountName,
    decimal Amount,
    string Status,
    AddressDto Address,
    string PaymentMethod,
    string PaymentStatus,
    List<OrderItemDto> Items,
    DateTime CreatedAt
);