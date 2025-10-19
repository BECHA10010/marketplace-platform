using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Infrastructure.Repositories;

public class RedisCachedShoppingCartRepository
    (IShoppingCartRepository repository, IDistributedCache cache) : IShoppingCartRepository
{
    public async Task<ShoppingCart> GetAsync(string accountName, CancellationToken ct)
    {
        var cached = await cache.GetStringAsync(accountName, ct);
        
        if (!string.IsNullOrEmpty(cached))
            return JsonSerializer.Deserialize<ShoppingCart>(cached)!;
        
        var cart = await repository.GetAsync(accountName, ct);
        await cache.SetStringAsync(accountName, JsonSerializer.Serialize(cart), ct);
        
        return cart;
    }

    public async Task AddAsync(ShoppingCart cart, CancellationToken ct)
    {
        await repository.AddAsync(cart, ct);
        await cache.SetStringAsync(cart.AccountName, JsonSerializer.Serialize(cart), ct);
    }

    public async Task DeleteAsync(string accountName, CancellationToken ct)
    {
        await repository.DeleteAsync(accountName, ct);
        await cache.RemoveAsync(accountName, ct);
    }
}