namespace Catalog.Application.Features.CatalogItems.Commands.RemoveCatalogItemById;

public class DeleteCatalogItemByIdHandler(ICatalogItemRepository repository)
    : ICommandHandler<DeleteCatalogItemByIdCommand, DeleteCatalogItemByIdResponse>
{
    public async Task<DeleteCatalogItemByIdResponse> Handle(DeleteCatalogItemByIdCommand command, CancellationToken cancellationToken)
    {
        var existing = await repository.GetAsync(command.Id, cancellationToken);

        if (existing is null)
            throw new CatalogItemNotFoundException(command.Id);

        await repository.DeleteAsync(command.Id, cancellationToken);
        
        return new DeleteCatalogItemByIdResponse(true);
    }
}