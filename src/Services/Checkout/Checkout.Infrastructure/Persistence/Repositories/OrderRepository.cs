namespace Checkout.Infrastructure.Persistence.Repositories;

public class OrderRepository(CheckoutDbContext context) 
    : BaseRepository<Order>(context), IOrderRepository
{
    public async Task<IReadOnlyList<Order>> GetByAccountName(string accountName, CancellationToken ct)
    {
        return await DbSet
            .Include(o => o.Items)
            .AsNoTracking()
            .Where(o => o.AccountName == accountName)
            .ToListAsync(ct);
    }

    public override async Task<IReadOnlyList<Order>> GetAllAsync(CancellationToken ct)
    {
        var result = await Context.Orders
            .Include(o => o.Items)
            .AsNoTracking()
            .ToListAsync(ct);

        return result;
    }

    public override async Task<Order?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var result = await Context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id, ct);

        return result;
    }
}