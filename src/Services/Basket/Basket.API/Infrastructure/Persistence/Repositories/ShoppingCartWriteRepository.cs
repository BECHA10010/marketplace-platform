namespace Basket.API.Infrastructure.Persistence.Repositories;

public class ShoppingCartWriteRepository(BasketDbContext context, IDistributedCache cache) : IShoppingCartWriteRepository
{
    public async Task<ShoppingCart?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await context.Carts
            .Include("_items")
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct)
    {
        return await context.Carts
            .Include("_items")
            .FirstOrDefaultAsync(x => x.AccountName == accountName, ct);
    }

    public async Task SaveAsync(ShoppingCart cart, CancellationToken ct)
    {
        if (context.Entry(cart).State == EntityState.Detached)
            context.Carts.Add(cart);

        await context.SaveChangesAsync(ct);
        
        await cache.RemoveAsync(cart.AccountName, ct);
    }
}