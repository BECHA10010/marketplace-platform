namespace Checkout.Tests.Integration.Database;

public static class DatabaseCleaner
{
    public static async Task ClearAsync(OrderDbContext context)
    {
        await context.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "OrderItem" RESTART IDENTITY CASCADE;
            TRUNCATE TABLE "Orders" RESTART IDENTITY CASCADE;
      """);
    }
}