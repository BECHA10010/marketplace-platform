using Common.Kernel.Domain.Abstractions.Repositories;

namespace Basket.API.Domain.Abstractions;

public interface IShoppingCartReadRepository : IReadRepository<ShoppingCart.ShoppingCart>
{
    Task<ShoppingCart.ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct);
}