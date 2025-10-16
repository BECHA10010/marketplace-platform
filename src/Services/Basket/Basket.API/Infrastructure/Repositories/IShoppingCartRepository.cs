using Basket.API.Infrastructure.Entities;
using Basket.API.Models;

namespace Basket.API.Infrastructure.Repositories;

public interface IShoppingCartRepository
{
    Task<ShoppingCartEntity?> GetByAccountAsync(string accountName, CancellationToken ct);
    Task<bool> DeleteByAccountAsync(string accountName, CancellationToken ct);
    Task AddAsync(ShoppingCartEntity entity, CancellationToken ct);
    Task UpdateAsync(ShoppingCartEntity entity, CancellationToken ct);
}