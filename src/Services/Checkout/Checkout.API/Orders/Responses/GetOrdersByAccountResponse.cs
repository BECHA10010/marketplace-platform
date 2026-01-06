namespace Checkout.API.Orders.Responses;

public record GetOrdersByAccountResponse(string AccountName, List<OrderResponse> Orders);

public record OrderResponse(
    Guid Id,
    decimal TotalAmount,
    string Status,
    DeliveryAddressResponse Address,
    string PaymentMethod,
    string PaymentStatus,
    List<OrderItemResponse> Items
);

public record DeliveryAddressResponse(string Street, string City);
public record OrderItemResponse(string Title, int Quantity, decimal UnitPrice);