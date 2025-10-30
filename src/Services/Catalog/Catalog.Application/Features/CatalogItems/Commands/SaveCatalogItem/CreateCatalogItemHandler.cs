namespace Catalog.Application.Features.CatalogItems.Commands.SaveCatalogItem;

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