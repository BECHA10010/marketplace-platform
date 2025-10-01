using Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemById;
using FluentValidation;

namespace Catalog.Application.Domains.CatalogItems.Commands.CreateCatalogItem;

public sealed partial record CreateCatalogItemCommand
{
    public sealed class Validator : AbstractValidator<CreateCatalogItemCommand>
    {
        public Validator()
        {
            RuleFor(item => item.Title)
                .NotEmpty().WithMessage("Title cannot be empty")
                .MaximumLength(50).WithMessage("Title must not exceed 50 characters");
            
            RuleFor(item => item.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");
            
            RuleFor(item => item.Brand)
                .NotNull().WithMessage("Brand is required");
            
            RuleFor(item => item.Category)
                .NotNull().WithMessage("Category is required");
        }
    }
}