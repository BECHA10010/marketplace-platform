namespace Basket.API.Infrastructure.Persistence.Repositories;

public class ShoppingCartReadRepository(BasketDbContext context) : IShoppingCartReadRepository
{
    public async Task<ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct)
    {
        return await context.Carts
            .AsNoTracking()
            .Include("_items")
            .FirstOrDefaultAsync(x => x.AccountName == accountName, ct);
    }
}