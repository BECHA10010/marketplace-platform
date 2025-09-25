namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class DeleteCatalogItemByIdCommandHandler(ICatalogItemRepository repository) : IRequestHandler<DeleteCatalogItemByIdCommand, DeleteCatalogItemByIdResult>
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