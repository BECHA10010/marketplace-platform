namespace Checkout.Infrastructure.Persistence;

public class CheckoutDbContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();

    public CheckoutDbContext(DbContextOptions<CheckoutDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}