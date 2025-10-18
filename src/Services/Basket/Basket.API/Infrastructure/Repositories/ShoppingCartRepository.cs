namespace Basket.API.Infrastructure.Repositories;

public class ShoppingCartRepository(BasketDbContext context) : IShoppingCartRepository
{
    public async Task<ShoppingCart?> GetAsync(string accountName, CancellationToken ct)
    {
        var cartEntity = await context.ShoppingCarts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.AccountName == accountName, ct);

        return cartEntity?.Adapt<ShoppingCart>();
    }

    public async Task AddAsync(ShoppingCart cart, CancellationToken ct)
    {
        var cartEntity = cart.Adapt<ShoppingCartEntity>();
        context.ShoppingCarts.Add(cartEntity);

        await context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(ShoppingCart cart, CancellationToken ct)
    {
        var existing = await context.ShoppingCarts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.AccountName == cart.AccountName, ct);

        if (existing is null)
            throw new CartNotFoundException(cart.AccountName);

        var cartEntity = cart.Adapt<ShoppingCartEntity>();
        
        existing.Items.Clear();
        existing.Items.AddRange(cartEntity.Items);

        await context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(string accountName, CancellationToken ct)
    {
        var cartEntity = await context.ShoppingCarts
            .FirstOrDefaultAsync(c => c.AccountName == accountName, ct);

        if (cartEntity is null)
            throw new CartNotFoundException(accountName);
        
        context.ShoppingCarts.Remove(cartEntity);
        await context.SaveChangesAsync(ct);
    }
}