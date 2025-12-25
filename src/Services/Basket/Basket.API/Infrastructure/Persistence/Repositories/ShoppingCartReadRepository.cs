using Basket.API.Domain.ShoppingCart;

namespace Basket.API.Infrastructure.Persistence.Repositories;

public class ShoppingCartReadRepository(BasketDbContext context) : IShoppingCartReadRepository
{
    public async Task<ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct)
    {
        return await context.ShoppingCarts
            .AsNoTracking()
            .Include("_items")
            .FirstOrDefaultAsync(x => x.AccountName == accountName, ct);
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