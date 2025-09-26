namespace Catalog.Application.Domains.CatalogItems.Commands.CreateCatalogItem;

public class CreateCatalogItemHandler(ICatalogItemRepository repository) 
    : IRequestHandler<CreateCatalogItemCommand, CreateCatalogItemResult>
{
    public async Task<CreateCatalogItemResult> Handle(CreateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var item = command.Adapt<CatalogItem>();
        item.Id = Guid.NewGuid();
        
        await repository.CreateCatalogItemAsync(item);

        return new CreateCatalogItemResult(item.Id);
    }
}