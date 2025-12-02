namespace Checkout.Application.Features.Orders.Common.DTOs;

public record OrderItemDto(string CatalogItemName, int Quantity, decimal UnitPrice);