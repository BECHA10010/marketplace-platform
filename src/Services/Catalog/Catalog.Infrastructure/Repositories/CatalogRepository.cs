namespace Catalog.Infrastructure.Repositories;

public class CatalogRepository(IDocumentSession session) : IBrandRepository, ICategoryRepository, ICatalogItemRepository
{
    public async Task<IReadOnlyList<Brand>> GetAllBrandsAsync()
    {
        return await session.Query<Brand>().ToListAsync();
    }

    public async Task<IReadOnlyList<Category>> GetAllCategoriesAsync()
    {
        var categories = await session.Query<Category>().ToListAsync();

        return categories;
    }

    public async Task<Pagination<CatalogItem>> GetCatalogItemsAsync(QueryArgs args)
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
        
        var itemsCount = await allItems.CountAsync();

        var items = await allItems
            .Skip((args.PageIndex - 1) * args.PageSize)
            .Take(args.PageSize)
            .ToListAsync();
        
        return new Pagination<CatalogItem>(args.PageIndex, args.PageSize, itemsCount, items);;
    }

    public async Task<CatalogItem?> GetCatalogItemAsync(Guid id)
    {
        return await session.LoadAsync<CatalogItem>(id);
    }

    public async Task<CatalogItem?> GetCatalogItemByTitleAsync(string title)
    {
        return await session.Query<CatalogItem>().SingleOrDefaultAsync(x => x.Title == title);
    }

    public async Task<IReadOnlyList<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle)
    {
        return await session.Query<CatalogItem>().Where(i => i.Brand!.Title == brandTitle).ToListAsync();
    }
    
    public async Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item)
    {
        session.Store(item);
        await session.SaveChangesAsync();
        
        return item;
    }

    public async Task<bool> UpdateCatalogItemAsync(CatalogItem item)
    {
        session.Store(item);
        await session.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteCatalogItemAsync(Guid id)
    {
        session.Delete<CatalogItem>(id);
        await session.SaveChangesAsync();

        return true;
    }
}