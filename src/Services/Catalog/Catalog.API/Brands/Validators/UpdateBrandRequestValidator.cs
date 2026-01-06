namespace Catalog.API.Brands.Validators;

public class UpdateBrandRequestValidator : AbstractValidator<UpdateBrandRequest>
{
    public UpdateBrandRequestValidator()
    {
        RuleFor(x => x.NewName)
            .NotEmpty().WithMessage("Brand name is required")
            .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters");
    }
}