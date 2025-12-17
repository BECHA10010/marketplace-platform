namespace Basket.API.Features.ShoppingCarts.Shared.DTOs;

public record CartItemResponse(
    Guid CatalogItemId,
    string Title, 
    int Quantity, 
    decimal UnitPrice,
    decimal Discount,
    decimal FinalPrice
);