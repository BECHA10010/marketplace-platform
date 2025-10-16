namespace Basket.API.Infrastructure.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    public Task<ShoppingCartEntity?> GetByAccountAsync(string accountName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByAccountAsync(string accountName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(ShoppingCartEntity entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ShoppingCartEntity entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}