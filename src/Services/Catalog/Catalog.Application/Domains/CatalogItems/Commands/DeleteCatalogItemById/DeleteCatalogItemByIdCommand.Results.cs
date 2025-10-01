namespace Catalog.Application.Domains.CatalogItems.Commands.DeleteCatalogItemById;

sealed partial record DeleteCatalogItemByIdCommand
{
    public static class Results
    {
        public sealed record SuccessResult();
        public sealed record FailResult(string Code, string Message);
    }
    
    private static Results.SuccessResult Success() 
        => new();

    private static Results.FailResult NotFound(Guid id) 
        => new(ApplicationErrors.NotFound, $"Catalog item with id {id} was not found");
    
    private static Results.FailResult DeleteFailed(Guid id) 
        => new(ApplicationErrors.DeleteFailed, $"Failed to delete catalog item with id {id}");
}