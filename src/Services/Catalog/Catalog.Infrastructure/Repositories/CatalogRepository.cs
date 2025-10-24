namespace Catalog.Infrastructure.Repositories;

public class CatalogRepository(IDocumentSession session) : ICatalogItemRepository
{
    public async Task<Pagination<CatalogItem>> GetAllAsync(QueryArgs args, CancellationToken ct)
    {
        var allItems = session.Query<CatalogItem>().AsQueryable();

        if (args.BrandId is not null)
            allItems = allItems.Where(x => x.Brand != null && x.Brand.Id == args.BrandId);
        
        if (args.CategoryId is not null)
            allItems = allItems.Where(x => x.Category != null && x.Category.Id == args.CategoryId);

        if (!string.IsNullOrWhiteSpace(args.Search))
        {
            allItems = allItems.Where(x => x.Title != null && x.Title.Contains(args.Search, StringComparison.OrdinalIgnoreCase));
        }
        
        if (!string.IsNullOrWhiteSpace(args.Sort))
        {
            allItems = args.Sort.ToLower() switch
            {
                "price_desc" => allItems.OrderByDescending(x => x.Price),
                "price_asc" => allItems.OrderBy(x => x.Price),
                "title_desc" => allItems.OrderByDescending(x => x.Title),
                "title_asc" => allItems.OrderBy(x => x.Title),
                _ => allItems
            };
        }
        
        var itemsCount = await allItems.CountAsync(ct);

        var items = await allItems
            .Skip((args.PageIndex - 1) * args.PageSize)
            .Take(args.PageSize)
            .ToListAsync(ct);
        
        return new Pagination<CatalogItem>(args.PageIndex, args.PageSize, itemsCount, items);
    }

    public async Task<CatalogItem?> GetAsync(Guid id, CancellationToken ct)
    {
        return await session.LoadAsync<CatalogItem>(id, ct);
    }

    public async Task<CatalogItem?> GetByTitleAsync(string title, CancellationToken ct)
    {
        return await session.Query<CatalogItem>().SingleOrDefaultAsync(x => x.Title == title, ct);
    }

    public async Task<IReadOnlyList<CatalogItem>> GetByBrandAsync(string brandTitle, CancellationToken ct)
    {
        return await session.Query<CatalogItem>().Where(i => i.Brand!.Title == brandTitle).ToListAsync(ct);
    }
    
    public async Task<CatalogItem> AddAsync(CatalogItem item, CancellationToken ct)
    {
        session.Store(item);
        await session.SaveChangesAsync(ct);
        
        return item;
    }

    public async Task UpdateAsync(CatalogItem item, CancellationToken ct)
    {
        session.Store(item);
        await session.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct)
    {
        session.Delete<CatalogItem>(id);
        await session.SaveChangesAsync(ct);
    }
}