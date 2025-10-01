namespace Catalog.Application.Domains.CatalogItems.Commands.UpdateCatalogItem;

public sealed partial record UpdateCatalogItemCommand
{
    public static class Results
    {
        public sealed record SuccessResult(CatalogItem UpdatedItem);
        public sealed record FailResult(string Code, string Message);
    }
    
    private static Results.SuccessResult Success(CatalogItem updatedItem) 
        => new(updatedItem);

    private static Results.FailResult NotFound(Guid id) 
        => new(ApplicationErrors.NotFound, $"Catalog item with id {id} was not found");
    
    private static Results.FailResult UpdateFailed(Guid id) 
        => new(ApplicationErrors.UpdateFailed, $"Failed to update catalog item with id {id}");
}