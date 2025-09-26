namespace Catalog.Application.Domains.CatalogItems.Commands.UpdateCatalogItem;

public class UpdateCatalogItemHandler(ICatalogItemRepository repository) 
    : IRequestHandler<UpdateCatalogItemCommand, UpdateCatalogItemResult>
{
    public async Task<UpdateCatalogItemResult> Handle(UpdateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var existingItem = await repository.GetCatalogItemAsync(command.Id);

        if (existingItem is null)
        {
            return new UpdateCatalogItemResult(false);
        }

        var catalogItem = command.Adapt<CatalogItem>();
        var isSuccess = await repository.UpdateCatalogItemAsync(catalogItem);

        return new UpdateCatalogItemResult(isSuccess);
    }
}