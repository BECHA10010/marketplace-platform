
namespace Catalog.Application.Features.CatalogItems.Queries.GetCatalogItemById;

public record GetCatalogItemByIdQuery(Guid Id) : IQuery<GetCatalogItemByIdResponse>;

public record GetCatalogItemByIdResponse(CatalogItem Item);

public class GetCatalogItemByIdHandler(ICatalogItemRepository repository)
    : IQueryHandler<GetCatalogItemByIdQuery, GetCatalogItemByIdResponse>
{
    public async Task<GetCatalogItemByIdResponse> Handle(GetCatalogItemByIdQuery query, CancellationToken cancellationToken)
    {
        var item = await repository.GetAsync(query.Id, cancellationToken);

        if (item is null)
            throw new CatalogItemNotFoundException(query.Id);
        
        return new GetCatalogItemByIdResponse(item);
    }
}