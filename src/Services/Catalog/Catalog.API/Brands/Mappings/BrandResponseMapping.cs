namespace Catalog.API.Brands.Mappings;

public static class BrandResponseMapping
{
    public static BrandResponse ToResponse(this BrandDto dto)
        => new (dto.Id, dto.Name);
    
    public static BrandsResponse ToResponseList(this IEnumerable<BrandDto> dtos)
        => new(dtos.Select(dto => dto.ToResponse()).ToList());
}