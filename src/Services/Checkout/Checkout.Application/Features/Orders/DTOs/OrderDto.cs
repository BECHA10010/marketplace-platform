using Checkout.Application.Features.Orders.CreateOrder;

namespace Checkout.Application.Orders.DTOs;

public record OrderDto(
    Guid Id,
    string AccountName,
    decimal TotalPrice,
    string OrderStatus,
    ContactDto ContactInfo,
    AddressDto DeliveryAddress,
    IEnumerable<OrderItemDto> Items,
    string PaymentMethod,
    GetOrdersPaymentDetailsDto? PaymentDetails,
    string PaymentStatus,
    DateTime CreatedAt
);