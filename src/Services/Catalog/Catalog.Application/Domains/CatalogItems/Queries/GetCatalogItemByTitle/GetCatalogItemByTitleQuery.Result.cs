namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemByTitle;

public sealed partial record GetCatalogItemByTitleQuery
{
    private static Results.SuccessResult Success(CatalogItem? item) 
        => new(item);

    private static Results.FailResult NotFound(string title) 
        => new(ApplicationErrors.ItemAlreadyExist, $"Item with title {title} already exist");
    
    public static class Results
    {
        public sealed record SuccessResult(CatalogItem? Item);
        public sealed record FailResult(string Code, string Message);
    }
}