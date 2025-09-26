namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItems;

public sealed partial record GetCatalogItemsQuery
{
    private static Results.SuccessResult Success(Pagination<CatalogItem> pagination) 
        => new(pagination);

    private static Results.FailResult NotFound(string title) 
        => new(ApplicationErrors.ItemAlreadyExist, $"Item with title {title} already exist");
    
    public static class Results
    {
        public sealed record SuccessResult(Pagination<CatalogItem> Pagination);
        public sealed record FailResult(string Code, string Message);
    }
}