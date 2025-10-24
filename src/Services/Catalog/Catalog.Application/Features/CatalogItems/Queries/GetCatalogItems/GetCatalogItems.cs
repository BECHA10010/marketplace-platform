namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItems;

public record GetCatalogItemsQuery(QueryArgs Args) : IQuery<GetCatalogItemsResponse>;

public record GetCatalogItemsResponse(Pagination<CatalogItem> Pagination);

public class GetCatalogItemsHandler(ICatalogItemRepository repository)
    : IQueryHandler<GetCatalogItemsQuery, GetCatalogItemsResponse>
{
    public async Task<GetCatalogItemsResponse> Handle(GetCatalogItemsQuery query, CancellationToken cancellationToken)
    {
        var items = await repository.GetAllAsync(query.Args, cancellationToken);
        
        return new GetCatalogItemsResponse(items);
    }
}