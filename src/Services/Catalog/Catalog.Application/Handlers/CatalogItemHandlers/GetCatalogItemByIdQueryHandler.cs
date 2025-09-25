using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemByIdQueryHandler(ICatalogItemRepository repository) : IRequestHandler<GetCatalogItemByIdQuery, GetCatalogItemByIdResult>
{
    public async Task<GetCatalogItemByIdResult> Handle(GetCatalogItemByIdQuery query, CancellationToken cancellationToken)
    {
        var catalogItem = await repository.GetCatalogItemAsync(query.Id);
        var result = new GetCatalogItemByIdResult(catalogItem);

        return result;
    }
}