namespace Common.Kernel.Domain;

public interface IWriteRepository<T> where T : IAggregateRoot
{
    Task AddAsync(T entity, CancellationToken ct);
    Task<bool> UpdateAsync(T entity, CancellationToken ct);
    Task<bool> DeleteAsync(T entity, CancellationToken ct);
}