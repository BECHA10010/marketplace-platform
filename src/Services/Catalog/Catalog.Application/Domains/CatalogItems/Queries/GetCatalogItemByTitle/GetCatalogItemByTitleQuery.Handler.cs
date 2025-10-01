namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemByTitle;

public sealed partial record GetCatalogItemByTitleQuery
{
    public sealed class Handler(ICatalogItemRepository repository) 
        : IRequestHandler<GetCatalogItemByTitleQuery, OneOf<Results.SuccessResult, Results.FailResult>>
    {
        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetCatalogItemByTitleQuery query, CancellationToken cancellationToken)
        {
            var item = await repository.GetCatalogItemByTitleAsync(query.Title, cancellationToken);

            if (item is null)
                return NotFound(query.Title);

            return Success(item);
        }
    }
}