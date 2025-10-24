namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemByTitle;

public class GetCatalogItemByTitleHandler(ICatalogItemRepository repository)
    : IQueryHandler<GetCatalogItemByTitleQuery, GetCatalogItemByTitleResponse>
{
    public async Task<GetCatalogItemByTitleResponse> Handle(GetCatalogItemByTitleQuery query, CancellationToken cancellationToken)
    {
        var item = await repository.GetByTitleAsync(query.Title, cancellationToken);
        
        if (item is null)
            throw new CatalogItemNotFoundException(query.Title);
        
        return new GetCatalogItemByTitleResponse(item);
    }
}