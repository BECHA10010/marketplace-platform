namespace Basket.API.Domain.ShoppingCart;

public interface IShoppingCartWriteRepository
{
    Task<ShoppingCart?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct);
    Task SaveAsync(ShoppingCart cart, CancellationToken ct);
}