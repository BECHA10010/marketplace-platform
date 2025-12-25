namespace Common.Kernel.Domain.Abstractions.Repositories;

public interface IWriteRepository<T> where T : IAggregateRoot
{
    Task AddAsync(T entity, CancellationToken ct);
    Task UpdateAsync(T entity, CancellationToken ct);
    Task DeleteAsync(T entity, CancellationToken ct);
}