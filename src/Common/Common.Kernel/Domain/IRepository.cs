namespace Common.Kernel.Domain;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : IAggregateRoot
{ }