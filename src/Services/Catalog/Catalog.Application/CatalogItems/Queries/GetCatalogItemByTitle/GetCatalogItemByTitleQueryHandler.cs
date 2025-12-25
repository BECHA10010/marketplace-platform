using Common.Kernel.Domain.Abstractions.Repositories;

namespace Catalog.Application.CatalogItems.Queries.GetCatalogItemByTitle;

public class GetCatalogItemByTitleQueryHandler(ICatalogItemQueryService queryService) : IQueryHandler<GetCatalogItemByTitleQuery, GetCatalogItemByTitleResult>
{
    public async Task<GetCatalogItemByTitleResult> Handle(GetCatalogItemByTitleQuery query, CancellationToken cancellationToken)
    {
        var item = await queryService.GetByTitleAsync(query.Title, cancellationToken);

        if (item is null)
            throw new NotFoundException(nameof(CatalogItem), query.Title);
        
        return new GetCatalogItemByTitleResult(item);
    }
}