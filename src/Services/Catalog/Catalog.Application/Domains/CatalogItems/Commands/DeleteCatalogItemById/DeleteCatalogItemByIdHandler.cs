namespace Catalog.Application.Domains.CatalogItems.Commands.DeleteCatalogItemById;

public class DeleteCatalogItemByIdHandler(ICatalogItemRepository repository) 
    : IRequestHandler<DeleteCatalogItemByIdCommand, DeleteCatalogItemByIdResult>
{
    public async Task<DeleteCatalogItemByIdResult> Handle(DeleteCatalogItemByIdCommand command, CancellationToken cancellationToken)
    {
        var existingItem = await repository.GetCatalogItemAsync(command.Id);

        if (existingItem is null)
        {
            return new DeleteCatalogItemByIdResult(false);
        }
        
        var isSuccess = await repository.DeleteCatalogItemAsync(command.Id);

        return new DeleteCatalogItemByIdResult(isSuccess);
    }
}