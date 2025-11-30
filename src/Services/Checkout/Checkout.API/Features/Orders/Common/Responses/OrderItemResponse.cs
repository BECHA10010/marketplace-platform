namespace Checkout.API.Features.Orders.Common.Responses;

public record OrderItemResponse(string CatalogItemName, int Quantity, decimal UnitPrice);