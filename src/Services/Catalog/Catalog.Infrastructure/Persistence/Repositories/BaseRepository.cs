namespace Catalog.Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<T>(CatalogDbContext context) : IRepository<T> 
    where T : BaseEntity, IAggregateRoot
{
    protected readonly CatalogDbContext Context = context;
    protected readonly DbSet<T> DbSet = context.Set<T>();
    
    // IReadRepository
    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public virtual async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct)
    {
        return await DbSet.AsNoTracking().ToListAsync(ct);
    }
    
    // IWriteRepository
    public virtual async Task AddAsync(T entity, CancellationToken ct)
    {
        await DbSet.AddAsync(entity, ct);
        await Context.SaveChangesAsync(ct);
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken ct)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync(ct);
    }

    public virtual async Task DeleteAsync(T entity, CancellationToken ct)
    {
        DbSet.Remove(entity);
        await Context.SaveChangesAsync(ct);
    }
}