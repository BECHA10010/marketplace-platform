namespace Catalog.Infrastructure.Repositories;

public class CatalogRepository(IDocumentSession session) : IBrandRepository, ICategoryRepository, ICatalogItemRepository
{
    public async Task<IReadOnlyList<Brand>> GetAllBrandsAsync(CancellationToken cancellationToken)
    {
        return await session.Query<Brand>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await session.Query<Category>().ToListAsync(cancellationToken);

        return categories;
    }

    public async Task<Pagination<CatalogItem>> GetCatalogItemsAsync(QueryArgs args, CancellationToken cancellationToken)
    {
        var allItems = session.Query<CatalogItem>().AsQueryable(); // .AsQueryable() преобразует => IQueryable<CatalogItem>

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
        
        var itemsCount = await allItems.CountAsync(cancellationToken);

        var items = await allItems
            .Skip((args.PageIndex - 1) * args.PageSize)
            .Take(args.PageSize)
            .ToListAsync(cancellationToken);
        
        return new Pagination<CatalogItem>(args.PageIndex, args.PageSize, itemsCount, items);
    }

    public async Task<CatalogItem?> GetCatalogItemAsync(Guid id, CancellationToken cancellationToken)
    {
        return await session.LoadAsync<CatalogItem>(id, cancellationToken);
    }

    public async Task<CatalogItem?> GetCatalogItemByTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await session.Query<CatalogItem>().SingleOrDefaultAsync(x => x.Title == title, cancellationToken);
    }

    public async Task<IReadOnlyList<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken cancellationToken)
    {
        return await session.Query<CatalogItem>().Where(i => i.Brand!.Title == brandTitle).ToListAsync(cancellationToken);
    }
    
    public async Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken)
    {
        session.Store(item);
        await session.SaveChangesAsync(cancellationToken);
        
        return item;
    }

    public async Task<bool> UpdateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken)
    {
        session.Store(item);
        await session.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken cancellationToken)
    {
        session.Delete<CatalogItem>(id);
        await session.SaveChangesAsync(cancellationToken);

        return true;
    }
}