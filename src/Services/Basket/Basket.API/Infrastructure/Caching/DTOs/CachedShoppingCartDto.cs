namespace Basket.API.Infrastructure.Caching.DTOs;

public record CachedShoppingCartDto(
    string AccountName,
    List<CachedCartItemDto> Items
);