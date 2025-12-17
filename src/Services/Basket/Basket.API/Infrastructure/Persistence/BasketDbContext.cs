namespace Basket.API.Infrastructure.Persistence;

public class BasketDbContext : DbContext
{
    public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();

    public BasketDbContext(DbContextOptions<BasketDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasketDbContext).Assembly);
    }
}