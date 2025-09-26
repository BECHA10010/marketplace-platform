namespace Catalog.Application.Domains.CatalogItems.Commands.UpdateCatalogItem;

public sealed partial record UpdateCatalogItemCommand
{
    private static Results.SuccessResult Success(bool isSuccess) 
        => new(isSuccess);

    private static Results.FailResult AlreadyExist(string title) 
        => new(ApplicationErrors.ItemAlreadyExist, $"Item with title {title} already exist");
    
    public static class Results
    {
        public sealed record SuccessResult(bool IsSuccess);
        public sealed record FailResult(string Code, string Message);
    }
}