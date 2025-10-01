namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItems;

public sealed partial record GetCatalogItemsQuery
{
    public sealed class Handler(ICatalogItemRepository repository) 
        : IRequestHandler<GetCatalogItemsQuery, OneOf<Results.SuccessResult, Results.FailResult>>
    {
        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetCatalogItemsQuery query, CancellationToken cancellationToken)
        {
            var items = await repository.GetCatalogItemsAsync(query.Args, cancellationToken);

            if (!items.Items.Any())
                return NotFound();
            
            return Success(items);
        }
    }
}