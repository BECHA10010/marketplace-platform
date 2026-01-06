using Basket.API.Domain.ShoppingCart;

namespace Basket.API.Infrastructure.Caching;

public class CachedShoppingCartReadRepository(IShoppingCartReadRepository inner, IDistributedCache cache) : IShoppingCartReadRepository
{
    private static DistributedCacheEntryOptions CacheOptions => new()
    {
        SlidingExpiration = TimeSpan.FromHours(2)
    };
    
    private static JsonSerializerOptions JsonOptions => new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public async Task<ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct)
    {
        var cached = await cache.GetStringAsync(accountName, ct);

        if (cached is not null)
        {
            try
            {
                return JsonSerializer.Deserialize<CachedShoppingCartDto>(cached, JsonOptions)?.ToDomain();
            }
            catch
            {
                await cache.RemoveAsync(accountName, ct);
            }
        }
        
        var cart = await inner.GetByAccountNameAsync(accountName, ct);

        if (cart is not null)
            await SetCacheAsync(cart, ct);

        return cart;
    }

    private Task SetCacheAsync(ShoppingCart cart, CancellationToken ct)
    { 
        return cache.SetStringAsync(
            cart.AccountName, 
            JsonSerializer.Serialize(cart.ToCachedDto(), JsonOptions), 
            CacheOptions,
            ct
        );
    }
}