namespace Catalog.Application.Domains.CatalogItems.Commands.CreateCatalogItem;

public sealed partial record CreateCatalogItemCommand
{
    public static class Results
    {
        public sealed record SuccessResult(Guid Id);
        public sealed record FailResult(string Code, string Message);
    }
    
    private static Results.SuccessResult Success(Guid id) 
        => new(id);

    private static Results.FailResult AlreadyExist(string title) 
        => new(ApplicationErrors.AlreadyExist, $"Catalog item with title '{title}' already exists");
    
    private static Results.FailResult CreateFailed(string title) 
        => new(ApplicationErrors.CreateFailed, $"Failed to create catalog item '{title}'");
}