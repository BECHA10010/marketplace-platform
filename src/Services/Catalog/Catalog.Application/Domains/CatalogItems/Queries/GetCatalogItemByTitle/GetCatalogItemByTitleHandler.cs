namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemByTitle;

public class GetCatalogItemByTitleHandler(ICatalogItemRepository repository) 
    : IRequestHandler<GetCatalogItemByTitleQuery, GetCatalogItemByTitleResult>
{
    public async Task<GetCatalogItemByTitleResult> Handle(GetCatalogItemByTitleQuery query, CancellationToken cancellationToken)
    {
        var catalogItems = await repository.GetCatalogItemByTitleAsync(query.Title);
        var result = new GetCatalogItemByTitleResult(catalogItems);
        
        return result;
    }
}