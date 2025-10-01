namespace Catalog.Application.Domains.Brands.Queries;

public sealed partial record GetBrandsQuery
{
    public static class Results
    {
        public sealed record SuccessResult(IEnumerable<Brand> Brands);
        public sealed record FailResult(string Code, string Message);
    }
    
    private static Results.SuccessResult Success(IEnumerable<Brand> brands) 
        => new(brands);

    private static Results.FailResult NotFound() 
        => new(ApplicationErrors.NotFound, $"No brands found");
}