namespace Catalog.Application.CatalogItems.Queries.GetCatalogItemByTitle;

public class GetCatalogItemByTitleQueryValidator : AbstractValidator<GetCatalogItemByTitleQuery>
{
    public GetCatalogItemByTitleQueryValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title must not be empty")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters");
    }
}