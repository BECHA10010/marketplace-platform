namespace Basket.API.Infrastructure.Caching.DTOs;

public record CachedCartItemDto(
    Guid CatalogItemId,
    string Title, 
    int Quantity, 
    decimal UnitPrice,
    decimal Discount
);