namespace Catalog.Application.Domains.Categories.Queries;

public sealed partial record GetCategoriesQuery
{
    private static Results.SuccessResult Success(IEnumerable<Category> categories) 
        => new(categories);

    private static Results.FailResult NotFound(string title) 
        => new(ApplicationErrors.ItemAlreadyExist, $"Item with title {title} already exist");
    
    public static class Results
    {
        public sealed record SuccessResult(IEnumerable<Category> Categories);
        public sealed record FailResult(string Code, string Message);
    }
}