namespace Common.Kernel.Domain.Abstractions.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : IAggregateRoot
{ }