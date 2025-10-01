namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemsByBrand;

public sealed partial record GetCatalogItemsByBrandQuery
{
    public static class Results
    {
        public sealed record SuccessResult(IEnumerable<CatalogItem> Items);
        public sealed record FailResult(string Code, string Message);
    }
    
    private static Results.SuccessResult Success(IEnumerable<CatalogItem> items) 
        => new(items);

    private static Results.FailResult NotFound(string brand) 
        => new(ApplicationErrors.NotFound, $"Items with brand {brand} not founds");
}