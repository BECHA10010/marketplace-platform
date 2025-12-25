using Basket.API.Domain.ShoppingCart;

namespace Basket.API.Infrastructure.Caching;

public class CachedShoppingCartReadRepository(IShoppingCartReadRepository inner, IDistributedCache cache)
    : IShoppingCartReadRepository
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
        var key = CacheKey(accountName);
        var cached = await cache.GetStringAsync(key, ct);

        if (cached is not null)
        {
            try
            {
                return JsonSerializer.Deserialize<CachedShoppingCartDto>(cached, JsonOptions)?.ToDomain();
            }
            catch
            {
                await cache.RemoveAsync(key, ct);
            }
        }
        
        var cart = await inner.GetByAccountNameAsync(accountName, ct);

        if (cart is not null)
            await SetCacheAsync(cart, ct);

        return cart;
    }
    
    private static string CacheKey(string accountName) => $"basket:{accountName}";

    private Task SetCacheAsync(ShoppingCart cart, CancellationToken ct)
    { 
        return cache.SetStringAsync(
            CacheKey(cart.AccountName), 
            JsonSerializer.Serialize(cart.ToCachedDto(), JsonOptions), 
            CacheOptions,
            ct
        );
    }

    public Task<ShoppingCart?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<ShoppingCart>> GetAllAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}