namespace Catalog.Application.Features.CatalogItems.Queries.GetPaginationCatalogItems;

public class GetPaginationCatalogItemsHandler(ICatalogItemRepository repository)
    : IQueryHandler<GetPaginationCatalogItemsQuery, GetPaginationCatalogItemsResponse>
{
    public async Task<GetPaginationCatalogItemsResponse> Handle(GetPaginationCatalogItemsQuery query, CancellationToken cancellationToken)
    {
        var items = await repository.GetAllWithPaginationAsync(query.Args, cancellationToken);
        
        return new GetPaginationCatalogItemsResponse(items);
    }
}