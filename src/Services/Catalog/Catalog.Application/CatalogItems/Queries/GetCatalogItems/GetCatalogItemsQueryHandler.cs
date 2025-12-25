namespace Catalog.Application.CatalogItems.Queries.GetCatalogItems;

public class GetCatalogItemsQueryHandler(ICatalogItemQueryService catalogItemsQueryService)
    : IQueryHandler<GetCatalogItemsQuery, GetCatalogItemsResult>
{
    public async Task<GetCatalogItemsResult> Handle(GetCatalogItemsQuery query, CancellationToken cancellationToken)
    {
        var items = await catalogItemsQueryService
            .GetAsync(query.Brand, query.Category, cancellationToken);

        return new GetCatalogItemsResult(items);
    }
}