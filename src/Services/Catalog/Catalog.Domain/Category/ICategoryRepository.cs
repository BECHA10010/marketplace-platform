using Common.Kernel.Domain.Abstractions.Repositories;

namespace Catalog.Domain.Category;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetByNameAsync(string name, CancellationToken ct);
}