namespace Checkout.Application.DTOs.ValueObjects;

public record OrderItemDto(string CatalogItemName, int Quantity, decimal UnitPrice);