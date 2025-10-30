namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemsByBrand;

public class GetCatalogItemsByBrandHandler(ICatalogItemRepository repository)
    : IQueryHandler<GetCatalogItemsByBrandQuery, GetCatalogItemsByBrandResponse>
{
    public async Task<GetCatalogItemsByBrandResponse> Handle(GetCatalogItemsByBrandQuery query, CancellationToken cancellationToken)
    {
        var items = await repository.GetByBrandAsync(query.BrandTitle, cancellationToken);
        
        return new GetCatalogItemsByBrandResponse(items);
    }
}