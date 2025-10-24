namespace Catalog.Domain.Abstractions;

public interface IBrandRepository
{
    Task<IReadOnlyList<Brand>> GetAllAsync(CancellationToken ct);
}