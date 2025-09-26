namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItems;

public class GetCatalogItemsHandler(ICatalogItemRepository repository) 
    : IRequestHandler<GetCatalogItemsQuery, GetCatalogItemsResult>
{
    public async Task<GetCatalogItemsResult> Handle(GetCatalogItemsQuery query, CancellationToken cancellationToken)
    {
        var result = await repository.GetCatalogItemsAsync(query.Args);
        
        return new GetCatalogItemsResult(result);
    }
}