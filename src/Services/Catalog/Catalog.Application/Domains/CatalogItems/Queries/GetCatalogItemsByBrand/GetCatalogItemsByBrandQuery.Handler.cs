namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemsByBrand;

public sealed partial record GetCatalogItemsByBrandQuery
{
    public sealed class Handler(ICatalogItemRepository repository)
        : IRequestHandler<GetCatalogItemsByBrandQuery, OneOf<Results.SuccessResult, Results.FailResult>>
    {
        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetCatalogItemsByBrandQuery query, CancellationToken cancellationToken)
        {
            var items = await repository.GetCatalogItemsByBrandAsync(query.BrandTitle, cancellationToken);

            if (!items.Any())
                return NotFound(query.BrandTitle);
            
            return Success(items);
        }
    }
}