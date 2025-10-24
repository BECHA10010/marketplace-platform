namespace Catalog.Application.Features.CatalogItems.Commands.UpdateCatalogItem;

public record UpdateCatalogItemRequest(
    Guid Id,
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price);

public record UpdateCatalogItemCommand(
    Guid Id,
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price) : ICommand<UpdateCatalogItemResponse>;

public record UpdateCatalogItemResponse(bool IsSuccess);

public class UpdateCatalogItemHandler(ICatalogItemRepository repository)
    : ICommandHandler<UpdateCatalogItemCommand, UpdateCatalogItemResponse>
{
    public async Task<UpdateCatalogItemResponse> Handle(UpdateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var existing = await repository.GetAsync(command.Id, cancellationToken);

        if (existing is null)
            throw new CatalogItemNotFoundException(command.Id);

        var item = command.Adapt<CatalogItem>();
        await repository.UpdateAsync(item, cancellationToken);
        
        return new UpdateCatalogItemResponse(true);
    }
}

public class UpdateCatalogItemValidator : AbstractValidator<UpdateCatalogItemCommand>
{
    public UpdateCatalogItemValidator()
    {
        RuleFor(item => item.Title)
            .NotEmpty().WithMessage("Title cannot be empty")
            .MaximumLength(50).WithMessage("Title must not exceed 50 characters");
            
        RuleFor(item => item.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero");
            
        RuleFor(item => item.Brand)
            .NotNull().WithMessage("Brand is required");
            
        RuleFor(item => item.Category)
            .NotNull().WithMessage("Category is required");
    }
}