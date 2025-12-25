namespace Checkout.API.Orders.Common.Requests;

public record OrderItemRequest(string CatalogItemName, int Quantity, decimal UnitPrice);