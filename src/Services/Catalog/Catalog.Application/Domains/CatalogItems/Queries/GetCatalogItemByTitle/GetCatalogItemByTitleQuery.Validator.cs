using FluentValidation;

namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemByTitle;

public sealed partial record GetCatalogItemByTitleQuery
{
    public sealed class Validator : AbstractValidator<GetCatalogItemByTitleQuery>
    {
        public Validator()
        {
            RuleFor(item => item.Title).NotEmpty().WithMessage("Title cannot be empty");
        }
    }
}