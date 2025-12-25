namespace Catalog.API.Brands.Validators;

public class CreateBrandRequestValidator : AbstractValidator<CreateBrandRequest>
{
    public CreateBrandRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Brand name is required")
            .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters");
    }
}