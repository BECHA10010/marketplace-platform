namespace Basket.API.Features.ShoppingCarts.Shared.DTOs;

public record CartItemDto(
    Guid CatalogItemId,
    string Title,
    int Quantity,
    decimal UnitPrice);