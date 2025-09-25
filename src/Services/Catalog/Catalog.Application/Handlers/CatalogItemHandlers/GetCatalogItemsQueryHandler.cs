namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsQueryHandler(ICatalogItemRepository catalogItemRepository) : IRequestHandler<GetCatalogItemsQuery, GetCatalogItemsResult>
{
    public async Task<GetCatalogItemsResult> Handle(GetCatalogItemsQuery query, CancellationToken cancellationToken)
    {
        var result = await catalogItemRepository.GetCatalogItemsAsync(query.Args);
        
        return new GetCatalogItemsResult(result);
    }
}