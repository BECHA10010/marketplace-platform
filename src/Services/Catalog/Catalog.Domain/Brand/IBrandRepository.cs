using Common.Kernel.Domain.Abstractions.Repositories;

namespace Catalog.Domain.Brand;

public interface IBrandRepository : IRepository<Brand>
{
    Task<Brand?> GetByNameAsync(string name, CancellationToken ct);
}