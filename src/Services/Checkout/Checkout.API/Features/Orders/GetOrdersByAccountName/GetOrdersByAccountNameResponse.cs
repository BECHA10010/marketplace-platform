namespace Checkout.API.Features.Orders.GetOrdersByAccountName;

public record GetOrdersByAccountNameResponse(string AccountName, List<OrderDataResponse> Orders);

public record OrderDataResponse(
    Guid Id,
    decimal Amount,
    string Status,
    AddressDataResponse Address,
    string PaymentMethod,
    string PaymentStatus,
    List<OrderItemResponse> Items,
    string CreatedAt
);

public record AddressDataResponse(string Street, string City);
public record OrderItemResponse(string CatalogItemName, int Quantity, decimal UnitPrice);
