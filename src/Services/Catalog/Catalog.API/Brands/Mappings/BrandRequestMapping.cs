namespace Catalog.API.Brands.Mappings;

public static class BrandRequestMapping
{
    public static CreateBrandDto ToCreateDto(this CreateBrandRequest request)
        => new(request.Name);
    
    public static UpdateBrandDto ToUpdateDto(this UpdateBrandRequest request)
        => new(request.NewName);
}