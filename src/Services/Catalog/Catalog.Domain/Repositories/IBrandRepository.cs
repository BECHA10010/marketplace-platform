namespace Catalog.Domain.Repositories;

public interface IBrandRepository
{
    Task<IReadOnlyList<Brand>> GetAllBrandsAsync();
}