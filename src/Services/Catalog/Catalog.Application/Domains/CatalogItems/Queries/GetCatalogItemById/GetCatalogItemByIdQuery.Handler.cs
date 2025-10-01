namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemById;

public sealed partial record GetCatalogItemByIdQuery
{
    public sealed class Handler(ICatalogItemRepository repository) 
        : IRequestHandler<GetCatalogItemByIdQuery, OneOf<Results.SuccessResult, Results.FailResult>>
    {
        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetCatalogItemByIdQuery query, CancellationToken cancellationToken)
        {
            var item = await repository.GetCatalogItemAsync(query.Id, cancellationToken);

            if (item is null)
                return NotFound(query.Id);

            return Success(item);
        }
    }
}