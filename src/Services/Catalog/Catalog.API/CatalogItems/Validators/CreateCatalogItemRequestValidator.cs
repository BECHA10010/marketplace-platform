namespace Catalog.API.CatalogItems.Validators;

public class CreateCatalogItemRequestValidator : AbstractValidator<CreateCatalogItemRequest>
{
    public CreateCatalogItemRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty")
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters");

        RuleFor(x => x.BrandName)
            .NotEmpty().WithMessage("Brand is required")
            .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters");

        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Category is required")
            .MaximumLength(50).WithMessage("Category name must not exceed 50 characters");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero");
    }
}