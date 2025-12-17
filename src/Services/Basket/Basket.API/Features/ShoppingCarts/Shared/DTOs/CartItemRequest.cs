namespace Basket.API.Features.ShoppingCarts.Shared.DTOs;

public record CartItemRequest(Guid CatalogItemId, string Title, int Quantity, decimal UnitPrice);