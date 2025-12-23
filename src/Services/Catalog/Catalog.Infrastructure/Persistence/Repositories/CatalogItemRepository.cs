namespace Catalog.Infrastructure.Persistence.Repositories;

public class CatalogItemRepository(CatalogDbContext context) 
    : BaseRepository<CatalogItem>(context), ICatalogItemRepository
{
    public async Task<CatalogItem?> GetByTitleAsync(string title, CancellationToken ct)
    {
        return await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Title == title, ct);
    }
}

/*public async Task<Pagination<CatalogItem>> GetAllWithPaginationAsync(QueryArgs args, CancellationToken ct)
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
    }*/