namespace Catalog.Application.CatalogItems.Queries.GetCatalogItemById;

public class GetCatalogItemByIdQueryHandler(ICatalogItemQueryService queryService) : IQueryHandler<GetCatalogItemByIdQuery, GetCatalogItemByIdResult>
{
    public async Task<GetCatalogItemByIdResult> Handle(GetCatalogItemByIdQuery query, CancellationToken cancellationToken)
    {
        var item = await queryService.GetByIdAsync(query.Id, cancellationToken);

        if (item is null)
            throw new NotFoundException(nameof(CatalogItem), query.Id);
        
        return new GetCatalogItemByIdResult(item);
    }
}