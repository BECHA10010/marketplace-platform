namespace Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemById;

public sealed partial record GetCatalogItemByIdQuery
{
    public static class Results
    {
        public sealed record SuccessResult(CatalogItem? Item);
        public sealed record FailResult(string Code, string Message);
    }
    
    private static Results.SuccessResult Success(CatalogItem? item) 
        => new(item);

    private static Results.FailResult NotFound(Guid id) 
        => new(ApplicationErrors.NotFound, $"Item with id {id} not found");
}