namespace Catalog.Infrastructure.Persistence.Services;

public class CatalogItemQueryService(CatalogDbContext context) : ICatalogItemQueryService
{
    public async Task<IReadOnlyList<CatalogItemDto>> GetAsync(string? brand, string? category, CancellationToken ct)
    {
        var query = BaseQuery();

        if (!string.IsNullOrWhiteSpace(brand))
            query = query.Where(x => x.Brand.Name == brand);

        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(x => x.Category.Name == category);

        return await query.Select(x => 
            new CatalogItemDto(
                x.Item.Id, 
                x.Item.Title, 
                x.Item.Description, 
                x.Brand.Name, 
                x.Category.Name, 
                x.Item.UnitPrice)
        ).ToListAsync(ct);
    }

    public async Task<CatalogItemDto?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await BaseQuery()
            .Where(x => x.Item.Id == id)
            .Select(x => new CatalogItemDto(
                x.Item.Id,
                x.Item.Title,
                x.Item.Description,
                x.Brand.Name,
                x.Category.Name,
                x.Item.UnitPrice)
            ).FirstOrDefaultAsync(ct);
    }

    public async Task<CatalogItemDto?> GetByTitleAsync(string title, CancellationToken ct)
    {
        return await BaseQuery()
            .Where(x => x.Item.Title == title)
            .Select(x => new CatalogItemDto(
                x.Item.Id,
                x.Item.Title,
                x.Item.Description,
                x.Brand.Name,
                x.Category.Name,
                x.Item.UnitPrice)
            ).FirstOrDefaultAsync(ct);
    }
    
    private IQueryable<CatalogItemQuery> BaseQuery()
    {
        return from item in context.CatalogItems.AsNoTracking()
            join brand in context.Brands on item.BrandId equals brand.Id
            join category in context.Categories on item.CategoryId equals category.Id
            select new CatalogItemQuery
            {
                Item = item,
                Brand = brand,
                Category = category
            };
    }
}

internal sealed record CatalogItemQuery
{
    public CatalogItem Item { get; init; } = default!;
    public Brand Brand { get; init; } = default!;
    public Category Category { get; init; } = default!;
}