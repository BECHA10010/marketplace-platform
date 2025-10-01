namespace Catalog.Application.Domains.Categories.Queries;

public sealed partial record GetCategoriesQuery
{
    public static class Results
    {
        public sealed record SuccessResult(IEnumerable<Category> Categories);
        public sealed record FailResult(string Code, string Message);
    }
    
    private static Results.SuccessResult Success(IEnumerable<Category> categories) 
        => new(categories);

    private static Results.FailResult NotFound() 
        => new(ApplicationErrors.NotFound, $"No categories found");
}