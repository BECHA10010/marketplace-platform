namespace Catalog.Application.Domains.CatalogItems.Commands.DeleteCatalogItemById;

sealed partial record DeleteCatalogItemByIdCommand
{
    public sealed class Handler(ICatalogItemRepository repository)
        : IRequestHandler<DeleteCatalogItemByIdCommand, OneOf<Results.SuccessResult, Results.FailResult>>
    {
        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(DeleteCatalogItemByIdCommand command, CancellationToken cancellationToken)
        {
            var existingItem = await repository.GetCatalogItemAsync(command.Id);

            if (existingItem is null)
                return NotFound(command.Id);

            var isSuccess = await repository.DeleteCatalogItemAsync(command.Id);
            
            return Success(isSuccess);
        }
    }
}