using Common.Kernel.Domain.Abstractions.Repositories;

namespace Basket.API.Domain.Abstractions;

public interface IShoppingCartWriteRepository : IWriteRepository<ShoppingCart.ShoppingCart>
{
    Task<ShoppingCart.ShoppingCart?> GetByAccountNameAsync(string accountName, CancellationToken ct);
    Task SaveAsync(ShoppingCart.ShoppingCart cart, CancellationToken ct);
}