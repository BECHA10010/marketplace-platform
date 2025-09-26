namespace Catalog.Application.Domains.Brands.Queries;

public sealed partial record GetBrandsQuery
{
    private static Results.SuccessResult Success(IEnumerable<Brand> brands) 
        => new(brands);

    private static Results.FailResult NotFound(string title) 
        => new(ApplicationErrors.ItemAlreadyExist, $"Item with title {title} already exist");
    
    public static class Results
    {
        public sealed record SuccessResult(IEnumerable<Brand> Brands);
        public sealed record FailResult(string Code, string Message);
    }
}