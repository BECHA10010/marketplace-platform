namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemsByBrand;

public sealed partial record GetCatalogItemsByBrandQuery
{
    private static Results.SuccessResult Success(IEnumerable<CatalogItem> items) 
        => new(items);

    private static Results.FailResult NotFound(string title) 
        => new(ApplicationErrors.ItemAlreadyExist, $"Item with title {title} already exist");
    
    public static class Results
    {
        public sealed record SuccessResult(IEnumerable<CatalogItem> Items);
        public sealed record FailResult(string Code, string Message);
    }
}