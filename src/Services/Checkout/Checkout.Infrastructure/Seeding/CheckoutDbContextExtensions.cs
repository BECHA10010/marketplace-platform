namespace Checkout.Infrastructure.Seeding;

public static class CheckoutDbContextExtensions
{
    public static async Task SeedAsync(this CheckoutDbContext checkoutDbContext)
    {
        if (!await checkoutDbContext.Orders.AnyAsync())
        {
            checkoutDbContext.Orders.AddRange(InitialData.Orders);
            await checkoutDbContext.SaveChangesAsync();
        }
    }
}