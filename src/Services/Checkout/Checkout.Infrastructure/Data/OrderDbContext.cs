namespace Checkout.Infrastructure.Data;

public class OrderDbContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();

    public OrderDbContext(DbContextOptions<OrderDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        HandleAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        HandleAuditFields();
        return base.SaveChanges();
    }

    private void HandleAuditFields()
    {
        var currentUser = $"User {Guid.NewGuid().ToString()[..5]}";

        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var item in entries)
        {
            switch (item.State)
            {
                case EntityState.Added:
                    item.Entity.SetCreatedAudit(currentUser);
                    break;
                
                case EntityState.Modified:
                    item.Entity.SetModifiedAudit(currentUser);
                    break;
            }
        }
    }
}