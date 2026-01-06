namespace Catalog.Application.Categories.Queries.GetCategoryByName;

public class GetCategoryByNameQueryValidator : AbstractValidator<GetCategoryByNameQuery>
{
    public GetCategoryByNameQueryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name must not be empty")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
    }
}