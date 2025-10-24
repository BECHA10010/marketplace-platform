namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemsV2;

public class GetCatalogItemsHandlerV2(ICatalogItemRepository repository)
    : IQueryHandler<GetCatalogItemsQueryV2, GetCatalogItemsResponseV2>
{
    public async Task<GetCatalogItemsResponseV2> Handle(GetCatalogItemsQueryV2 query, CancellationToken cancellationToken)
    {
        var items = await repository.GetAllAsync(query.Args, cancellationToken);
        
        return new GetCatalogItemsResponseV2(items);
    }
}