namespace Checkout.Infrastructure.Data.Seed;

public static class OrderDbContextSeed
{
    public static async Task SeedAsync(OrderDbContext orderDbContext)
    {
        if (!await orderDbContext.Orders.AnyAsync())
        {
            var orders = InitialData.Orders.ToList();

            foreach (var order in orders)
            {
                order.SetCreatedAudit("System");
            }
            
            orderDbContext.Orders.AddRange(orders);
            await orderDbContext.SaveChangesAsync();
        }
    }
}