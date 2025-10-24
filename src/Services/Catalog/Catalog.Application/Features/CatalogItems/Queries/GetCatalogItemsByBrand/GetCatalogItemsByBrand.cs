namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemsByBrand;


public record GetCatalogItemsByBrandQuery(string BrandTitle) : IQuery<GetCatalogItemsByBrandResponse>;

public record GetCatalogItemsByBrandResponse(IReadOnlyList<CatalogItem> Items);

public class GetCatalogItemsByBrandHandler(ICatalogItemRepository repository)
    : IQueryHandler<GetCatalogItemsByBrandQuery, GetCatalogItemsByBrandResponse>
{
    public async Task<GetCatalogItemsByBrandResponse> Handle(GetCatalogItemsByBrandQuery query, CancellationToken cancellationToken)
    {
        var items = await repository.GetByBrandAsync(query.BrandTitle, cancellationToken);
        
        return new GetCatalogItemsByBrandResponse(items);
    }
}