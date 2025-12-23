namespace Catalog.Application.CatalogItems.Queries.GetCatalogItems;

public class GetCatalogItemsQueryHandler(ICatalogItemsQueryService catalogItemsQueryService)
    : IQueryHandler<GetCatalogItemsQuery, GetCatalogItemsResult>
{
    public async Task<GetCatalogItemsResult> Handle(GetCatalogItemsQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<CatalogItemDto>? items;
        if (query.Brand is not null)
        {
            items = await catalogItemsQueryService.GetByBrandAsync(query.Brand, cancellationToken);
            return new GetCatalogItemsResult(items);
        }
        
        if (query.Category is not null)
        {
            items = await catalogItemsQueryService.GetByCategoryAsync(query.Category, cancellationToken);
            return new GetCatalogItemsResult(items);
        }
        
        items = await catalogItemsQueryService.GetAllAsync(cancellationToken);
        return new GetCatalogItemsResult(items);
    }
}