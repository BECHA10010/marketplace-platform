namespace Checkout.API.Features.Orders.Common.Responses;

public record OrderResponse(
    Guid Id,
    decimal Amount,
    string Status,
    AddressDataResponse Address,
    string PaymentMethod,
    string PaymentStatus,
    List<OrderItemResponse> Items,
    string CreatedAt
);