namespace Checkout.Domain.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByAccountName(string accountName);
}