namespace Catalog.Application.Brands.Commands.RemoveBrand;

public class RemoveBrandCommandValidator : AbstractValidator<RemoveBrandCommand>
{
    public RemoveBrandCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Catalog item id must not be empty");
    }   
}