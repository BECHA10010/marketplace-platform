namespace Basket.API.Domain.Abstractions;

public interface IShoppingCartWriteRepository : IWriteRepository<ShoppingCart>
{
    Task<ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct);
    Task SaveAsync(ShoppingCart cart, CancellationToken ct);
}