namespace Catalog.Application.Domains.CatalogItems.Commands.CreateCatalogItem;

public sealed partial record CreateCatalogItemCommand
{
    public sealed class Handler(ICatalogItemRepository repository) 
        : IRequestHandler<CreateCatalogItemCommand, OneOf<Results.SuccessResult, Results.FailResult>>
    {
        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(CreateCatalogItemCommand command, CancellationToken cancellationToken)
        {
            var existingItem = await repository.GetCatalogItemByTitleAsync(command.Title!, cancellationToken); // required поле

            if (existingItem is not null)
                return AlreadyExist(command.Title!);

            var newItem = command.Adapt<CatalogItem>();
            newItem.Id = Guid.NewGuid();
            
            await repository.CreateCatalogItemAsync(newItem, cancellationToken);

            return Success(newItem.Id);
        }
    }
}