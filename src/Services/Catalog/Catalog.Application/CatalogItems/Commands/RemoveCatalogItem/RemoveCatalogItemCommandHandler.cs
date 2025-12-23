namespace Catalog.Application.CatalogItems.Commands.RemoveCatalogItem;

public class RemoveCatalogItemCommandHandler(ICatalogItemRepository catalogItemRepository)
    : ICommandHandler<RemoveCatalogItemCommand>
{
    public async Task<Unit> Handle(RemoveCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var item = await catalogItemRepository.GetByIdAsync(command.Id, cancellationToken);

        if (item is null)
            throw new NotFoundException(nameof(CatalogItem), command.Id);

        await catalogItemRepository.DeleteAsync(item, cancellationToken);
        
        return default;
    }
}