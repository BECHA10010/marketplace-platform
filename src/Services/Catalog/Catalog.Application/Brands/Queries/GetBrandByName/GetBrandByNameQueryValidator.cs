namespace Catalog.Application.Brands.Queries.GetBrandByName;

public class GetBrandByNameQueryValidator : AbstractValidator<GetBrandByNameQuery>
{
    public GetBrandByNameQueryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name must not be empty")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
    }
}