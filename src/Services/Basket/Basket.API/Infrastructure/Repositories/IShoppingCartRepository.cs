namespace Basket.API.Infrastructure.Repositories;

public interface IShoppingCartRepository
{
    Task<ShoppingCart> GetAsync(string accountName, CancellationToken ct);
    Task AddAsync(ShoppingCart cart, CancellationToken ct);
    Task DeleteAsync(string accountName, CancellationToken ct);
}