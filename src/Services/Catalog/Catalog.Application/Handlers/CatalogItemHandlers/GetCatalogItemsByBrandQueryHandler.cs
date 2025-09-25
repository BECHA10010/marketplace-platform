using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsByBrandQueryHandler(ICatalogItemRepository repository) 
    : IRequestHandler<GetCatalogItemsByBrandQuery, GetCatalogItemsByBrandResult>
{
    public async Task<GetCatalogItemsByBrandResult> Handle(GetCatalogItemsByBrandQuery query, CancellationToken cancellationToken)
    {
        var items = await repository.GetCatalogItemsByBrandAsync(query.BrandTitle);
        var result = new GetCatalogItemsByBrandResult(items);

        return result;
    }
}