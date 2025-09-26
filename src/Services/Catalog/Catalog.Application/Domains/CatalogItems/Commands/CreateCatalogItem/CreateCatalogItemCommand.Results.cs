namespace Catalog.Application.Domains.CatalogItems.Commands.CreateCatalogItem;

public sealed partial record CreateCatalogItemCommand
{
    private static Results.SuccessResult Success(Guid id) 
        => new(id);

    private static Results.FailResult AlreadyExist(string title) 
        => new(ApplicationErrors.ItemAlreadyExist, $"Item with title {title} already exist");
    
    public static class Results
    {
        public sealed record SuccessResult(Guid Id);
        public sealed record FailResult(string Code, string Message);
    }
}