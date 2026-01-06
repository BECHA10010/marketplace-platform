namespace Catalog.Application.Categories.Commands.RemoveCategory;

public class RemoveCategoryCommandValidator : AbstractValidator<RemoveCategoryCommand>
{
    public RemoveCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Catalog item id must not be empty");
    }
}