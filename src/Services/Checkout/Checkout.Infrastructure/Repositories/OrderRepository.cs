namespace Checkout.Infrastructure.Repositories;

public class OrderRepository(OrderDbContext context) 
    : BaseRepository<Order>(context), IOrderRepository
{
    public async Task<IEnumerable<Order>> GetOrdersByAccountName(string accountName)
    {
        var result = await DbContext.Orders
            .Include(o => o.Items)
            .AsNoTracking()
            .Where(o => o.AccountName == accountName)
            .ToListAsync();

        return result;
    }

    public override async Task<IReadOnlyList<Order>> GetAllAsync()
    {
        var result = await DbContext.Orders
            .Include(o => o.Items)
            .AsNoTracking()
            .ToListAsync();

        return result;
    }

    public override async Task<Order?> GetByIdAsync(Guid id)
    {
        var result = await DbContext.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);

        return result;
    }
}