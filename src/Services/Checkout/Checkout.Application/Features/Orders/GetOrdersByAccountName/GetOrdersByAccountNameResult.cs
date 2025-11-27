using Checkout.Application.Features.Orders.CreateOrder;

namespace Checkout.Application.Features.Orders.GetOrdersByAccountName;

public record GetOrdersByAccountNameResult(List<OrderDto> Orders);

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