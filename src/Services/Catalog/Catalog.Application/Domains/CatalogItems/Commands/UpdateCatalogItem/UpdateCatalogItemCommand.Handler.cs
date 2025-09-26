namespace Catalog.Application.Domains.CatalogItems.Commands.UpdateCatalogItem;

public sealed partial record UpdateCatalogItemCommand
{
    public sealed class Handler(ICatalogItemRepository repository)
        : IRequestHandler<UpdateCatalogItemCommand, OneOf<Results.SuccessResult, Results.FailResult>>
    {
        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(UpdateCatalogItemCommand command, CancellationToken cancellationToken)
        {
            var existingItem = await repository.GetCatalogItemAsync(command.Id);

            if (existingItem is null)
                return AlreadyExist(command.Title!);

            var catalogItem = command.Adapt<CatalogItem>();
            var isSuccess = await repository.UpdateCatalogItemAsync(catalogItem);

            return Success(isSuccess);
        }
    }
}