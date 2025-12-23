namespace Catalog.Application.CatalogItems.Queries.GetCatalogItemById;

public class GetCatalogItemByIdQueryValidator : AbstractValidator<GetCatalogItemByIdQuery>
{
    public GetCatalogItemByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Catalog item id must not be empty");
    }
}