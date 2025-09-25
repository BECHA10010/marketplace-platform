using Catalog.Application.Commands.CatalogItemCommands;
using Catalog.Domain.Repositories;
using Mapster;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class CreateCatalogItemCommandHandler(ICatalogItemRepository repository) 
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