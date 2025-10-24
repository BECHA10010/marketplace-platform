namespace Catalog.Application.Features.CatalogItems.Commands.UpdateCatalogItem;

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