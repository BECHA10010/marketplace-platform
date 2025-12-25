namespace Checkout.Domain.Order;

public interface IOrderRepository : IRepository<Order>
{
    Task<IReadOnlyList<Order>> GetByAccountName(string accountName, CancellationToken ct);
}