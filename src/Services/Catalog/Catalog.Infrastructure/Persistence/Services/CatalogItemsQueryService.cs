namespace Catalog.Infrastructure.Persistence.Services;

public class CatalogItemsQueryService(CatalogDbContext context) : ICatalogItemsQueryService
{
    public async Task<IReadOnlyList<CatalogItemDto>> GetAllAsync(CancellationToken ct)
    {
        return await BaseQuery()
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<CatalogItemDto>> GetByBrandAsync(string brandName, CancellationToken ct)
    {
        return await BaseQuery()
            .Where(x => x.Brand == brandName)
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<CatalogItemDto>> GetByCategoryAsync(string categoryName, CancellationToken ct)
    {
        return await BaseQuery()
            .Where(x => x.Category == categoryName)
            .ToListAsync(ct);
    }
    
    private IQueryable<CatalogItemDto> BaseQuery()
    {
        return from item in context.CatalogItems.AsNoTracking()
            join brand in context.Brands on item.BrandId equals brand.Id 
            join category in context.Categories on item.CategoryId equals category.Id 
            select new CatalogItemDto(item.Title, item.Description, brand.Name, category.Name, item.UnitPrice);
    }
}