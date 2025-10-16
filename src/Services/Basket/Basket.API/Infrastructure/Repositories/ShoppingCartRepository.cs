namespace Basket.API.Infrastructure.Repositories;

public class ShoppingCartRepository(BasketDbContext context) : IShoppingCartRepository
{
    public async Task<ShoppingCartEntity?> GetByAccountAsync(string accountName, CancellationToken ct)
        => await context.ShoppingCarts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.AccountName == accountName, ct);

    public async Task<bool> DeleteByAccountAsync(string accountName, CancellationToken ct)
    {
        var cart = await context.ShoppingCarts
            .FirstOrDefaultAsync(c => c.AccountName == accountName, ct);

        if (cart is null)
            return false;
        
        context.ShoppingCarts.Remove(cart);
        await context.SaveChangesAsync(ct);

        return true;
    }

    public async Task AddOrUpdateAsync(ShoppingCartEntity entity, CancellationToken ct)
    {
        var existing = await context.ShoppingCarts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.AccountName == entity.AccountName, ct);

        if (existing is null)
        {
            context.ShoppingCarts.Add(entity);
        }
        else
        {
            existing.Items.Clear();
            existing.Items.AddRange(entity.Items);
        }
        
        await context.SaveChangesAsync(ct);
    }
}