namespace Basket.API.Domain.Abstractions;

public interface IShoppingCartReadRepository : IReadRepository<ShoppingCart>
{
    Task<ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct);
}