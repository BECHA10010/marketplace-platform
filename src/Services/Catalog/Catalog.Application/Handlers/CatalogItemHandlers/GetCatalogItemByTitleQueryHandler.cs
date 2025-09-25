using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemByTitleQueryHandler(ICatalogItemRepository repository) : IRequestHandler<GetCatalogItemByTitleQuery, GetCatalogItemByTitleResult>
{
    public async Task<GetCatalogItemByTitleResult> Handle(GetCatalogItemByTitleQuery query, CancellationToken cancellationToken)
    {
        var catalogItems = await repository.GetCatalogItemByTitleAsync(query.Title);
        var result = new GetCatalogItemByTitleResult(catalogItems);
        
        return result;
    }
}