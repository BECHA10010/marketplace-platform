namespace Checkout.Application.Orders.DTOs;

public record OrderItemDto(string CatalogItemName, int Quantity, decimal UnitPrice);