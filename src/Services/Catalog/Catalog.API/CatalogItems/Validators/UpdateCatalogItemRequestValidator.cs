namespace Catalog.API.CatalogItems.Validators;

public class UpdateCatalogItemRequestValidator : AbstractValidator<UpdateCatalogItemRequest>
{
    public UpdateCatalogItemRequestValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters")
            .When(x => x.Title is not null);

        RuleFor(x => x.Description)
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters")
            .When(x => x.Description is not null);

        RuleFor(x => x.BrandName)
            .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters")
            .When(x => x.BrandName is not null);

        RuleFor(x => x.CategoryName)
            .MaximumLength(50).WithMessage("Category name must not exceed 50 characters")
            .When(x => x.CategoryName is not null);

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero")
            .When(x => x.Price.HasValue);
    }
}