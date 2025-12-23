namespace Catalog.Application.CatalogItems.Queries.GetCatalogItemById;

public class GetCatalogItemByIdQueryHandler(
    IReadRepository<CatalogItem> catalogItemRepository,
    IReadRepository<Brand> brandRepository,
    IReadRepository<Category> categoryRepository) : IQueryHandler<GetCatalogItemByIdQuery, GetCatalogItemByIdResult>
{
    public async Task<GetCatalogItemByIdResult> Handle(GetCatalogItemByIdQuery query, CancellationToken cancellationToken)
    {
        var item = await catalogItemRepository.GetByIdAsync(query.Id, cancellationToken);

        if (item is null)
            throw new NotFoundException(nameof(CatalogItem), query.Id);

        var brand = await brandRepository.GetByIdAsync(item.BrandId, cancellationToken);
        var category = await categoryRepository.GetByIdAsync(item.CategoryId, cancellationToken);
        
        var result = new CatalogItemDto(
            item.Title,
            item.Description,
            brand!.Name,
            category!.Name,
            item.UnitPrice
        );
        
        return new GetCatalogItemByIdResult(result);
    }
}