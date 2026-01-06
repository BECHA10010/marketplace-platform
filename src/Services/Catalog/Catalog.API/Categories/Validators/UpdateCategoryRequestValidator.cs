namespace Catalog.API.Categories.Validators;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        RuleFor(x => x.NewName)
            .NotEmpty().WithMessage("Brand name is required")
            .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters");
    }
}