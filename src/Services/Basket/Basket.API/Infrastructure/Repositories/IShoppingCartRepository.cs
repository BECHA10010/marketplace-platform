namespace Basket.API.Infrastructure.Repositories;

public interface IShoppingCartRepository
{
    Task<ShoppingCartEntity?> GetByAccountAsync(string accountName, CancellationToken ct);
    Task<bool> DeleteByAccountAsync(string accountName, CancellationToken ct);
    Task AddOrUpdateAsync(ShoppingCartEntity entity, CancellationToken ct);
}