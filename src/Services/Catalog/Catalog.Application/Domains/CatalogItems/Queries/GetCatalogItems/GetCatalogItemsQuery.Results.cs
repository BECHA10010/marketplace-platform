namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItems;

public sealed partial record GetCatalogItemsQuery
{
    public static class Results
    {
        public sealed record SuccessResult(Pagination<CatalogItem> Pagination);
        public sealed record FailResult(string Code, string Message);
    }
    
    private static Results.SuccessResult Success(Pagination<CatalogItem> pagination) 
        => new(pagination);

    private static Results.FailResult NotFound() 
        => new(ApplicationErrors.NotFound, $"Items not found");
}