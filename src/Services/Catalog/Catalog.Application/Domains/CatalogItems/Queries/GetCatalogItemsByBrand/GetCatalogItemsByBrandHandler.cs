namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemsByBrand;

public class GetCatalogItemsByBrandHandler(ICatalogItemRepository repository) 
    : IRequestHandler<GetCatalogItemsByBrandQuery, GetCatalogItemsByBrandResult>
{
    public async Task<GetCatalogItemsByBrandResult> Handle(GetCatalogItemsByBrandQuery query, CancellationToken cancellationToken)
    {
        var items = await repository.GetCatalogItemsByBrandAsync(query.BrandTitle);
        var result = new GetCatalogItemsByBrandResult(items);

        return result;
    }
}