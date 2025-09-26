namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemById;

public class GetCatalogItemByIdHandler(ICatalogItemRepository repository) 
    : IRequestHandler<GetCatalogItemByIdQuery, GetCatalogItemByIdResult>
{
    public async Task<GetCatalogItemByIdResult> Handle(GetCatalogItemByIdQuery query, CancellationToken cancellationToken)
    {
        var catalogItem = await repository.GetCatalogItemAsync(query.Id);
        var result = new GetCatalogItemByIdResult(catalogItem);

        return result;
    }
}