namespace Basket.API.Domain.ShoppingCart;

public interface IShoppingCartReadRepository
{
    Task<ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct);
}