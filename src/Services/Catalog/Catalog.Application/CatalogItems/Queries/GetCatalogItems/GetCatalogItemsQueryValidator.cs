namespace Catalog.Application.CatalogItems.Queries.GetCatalogItems;

public class GetCatalogItemsQueryValidator : AbstractValidator<GetCatalogItemsQuery>
{
    public GetCatalogItemsQueryValidator()
    {
        RuleFor(x => x.Brand)
            .MaximumLength(50)
            .When(x => x.Brand is not null);

        RuleFor(x => x.Category)
            .MaximumLength(50)
            .When(x => x.Category is not null);
    }
}