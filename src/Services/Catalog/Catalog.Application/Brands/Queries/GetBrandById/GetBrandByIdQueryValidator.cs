namespace Catalog.Application.Brands.Queries.GetBrandById;

public class GetBrandByIdQueryValidator : AbstractValidator<GetBrandByIdQuery>
{
    public GetBrandByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Catalog item id must not be empty");
    }
}