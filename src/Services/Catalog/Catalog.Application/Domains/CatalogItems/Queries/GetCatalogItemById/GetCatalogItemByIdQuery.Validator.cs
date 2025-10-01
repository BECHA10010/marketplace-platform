namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemById;

public sealed partial record GetCatalogItemByIdQuery
{
    public sealed class Validator : AbstractValidator<GetCatalogItemByIdQuery>
    {
        public Validator()
        {
            RuleFor(item => item.Id).NotEmpty().WithMessage("Id cannot be empty");
        }
    }
}