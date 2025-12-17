namespace Basket.API.Infrastructure.Persistence.Repositories;

public class ShoppingCartWriteRepository(BasketDbContext context, IDistributedCache cache) : IShoppingCartWriteRepository
{
    public async Task<ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct)
    {
        return await context.ShoppingCarts
            .Include("_items")
            .FirstOrDefaultAsync(x => x.AccountName == accountName, ct);
    }

    public async Task SaveAsync(ShoppingCart cart, CancellationToken ct)
    {
        if (context.Entry(cart).State == EntityState.Detached)
            context.ShoppingCarts.Add(cart);

        await context.SaveChangesAsync(ct);

        await cache.RemoveAsync($"basket:{cart.AccountName}", ct);
        
        /*var entry = context.Entry(cart);

        if (entry.State == EntityState.Detached)
        {
            context.Attach(cart);
            entry.State = EntityState.Modified;
        }

        await context.SaveChangesAsync(ct);

        await cache.RemoveAsync($"basket:{cart.AccountName}", ct);*/
    }
}