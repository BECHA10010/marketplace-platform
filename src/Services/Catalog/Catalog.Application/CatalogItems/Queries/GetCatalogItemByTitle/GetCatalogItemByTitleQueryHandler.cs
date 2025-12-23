namespace Catalog.Application.CatalogItems.Queries.GetCatalogItemByTitle;

public class GetCatalogItemByTitleQueryHandler(
    ICatalogItemRepository catalogItemRepository,
    IReadRepository<Brand> brandRepository,
    IReadRepository<Category> categoryRepository) : IQueryHandler<GetCatalogItemByTitleQuery, GetCatalogItemByTitleResult>
{
    public async Task<GetCatalogItemByTitleResult> Handle(GetCatalogItemByTitleQuery query, CancellationToken cancellationToken)
    {
        var item = await catalogItemRepository.GetByTitleAsync(query.Title, cancellationToken);

        if (item is null)
            throw new NotFoundException(nameof(CatalogItem), query.Title);
        
        var brand = await brandRepository.GetByIdAsync(item.BrandId, cancellationToken);
        var category = await categoryRepository.GetByIdAsync(item.CategoryId, cancellationToken);
        
        var result = new CatalogItemDto(
            item.Title,
            item.Description,
            brand!.Name,
            category!.Name,
            item.UnitPrice
        );
        
        return new GetCatalogItemByTitleResult(result);
    }
}