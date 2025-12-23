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

        RuleFor(x => x)
            .Must(x => !(x.Brand is not null && x.Category is not null))
            .WithMessage("Only one filter (brand or category) can be specified");
    }
}