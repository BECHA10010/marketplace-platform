namespace Catalog.Application.Features.CatalogItems.Commands.SaveCatalogItem;

public record CreateCatalogItemRequest(
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price);

public record CreateCatalogItemCommand(
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price) : ICommand<CreateCatalogItemResponse>;

public record CreateCatalogItemResponse(Guid Id);

public class CreateCatalogItemHandler(ICatalogItemRepository repository)
    : ICommandHandler<CreateCatalogItemCommand, CreateCatalogItemResponse>
{
    public async Task<CreateCatalogItemResponse> Handle(CreateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var existing = await repository.GetByTitleAsync(command.Title!, cancellationToken);

        if (existing is not null)
            throw new CatalogItemAlreadyExistsException(command.Title!);

        var newItem = command.Adapt<CatalogItem>();
        newItem.Id = Guid.NewGuid();
        
        await repository.AddAsync(newItem, cancellationToken);
        
        return new CreateCatalogItemResponse(newItem.Id);
    }
}

public class CreateCatalogItemValidator : AbstractValidator<CreateCatalogItemCommand>
{
    public CreateCatalogItemValidator()
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