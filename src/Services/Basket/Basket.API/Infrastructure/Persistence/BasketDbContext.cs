using Basket.API.Domain.ShoppingCart;

namespace Basket.API.Infrastructure.Persistence;

public class BasketDbContext : DbContext
{
    public DbSet<ShoppingCart> Carts => Set<ShoppingCart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();

    public BasketDbContext(DbContextOptions<BasketDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasketDbContext).Assembly);
    }
}