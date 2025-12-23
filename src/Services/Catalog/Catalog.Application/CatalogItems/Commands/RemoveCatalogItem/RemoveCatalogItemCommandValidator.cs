namespace Catalog.Application.CatalogItems.Commands.RemoveCatalogItem;

public class RemoveCatalogItemCommandValidator : AbstractValidator<RemoveCatalogItemCommand>
{
    public RemoveCatalogItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Catalog item id must not be empty");
    }
}