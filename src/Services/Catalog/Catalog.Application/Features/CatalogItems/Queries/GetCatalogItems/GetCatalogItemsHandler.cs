namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItems;

public class GetCatalogItemsHandler(ICatalogItemRepository repository)
    : IQueryHandler<GetCatalogItemsQuery, GetCatalogItemsResponse>
{
    public async Task<GetCatalogItemsResponse> Handle(GetCatalogItemsQuery query, CancellationToken cancellationToken)
    {
        var items = await repository.GetAllAsync(cancellationToken);
        
        return new GetCatalogItemsResponse(items);
    }
}