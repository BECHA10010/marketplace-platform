namespace Catalog.Application.CatalogItems.Commands.UpdateCatalogItem;

public class UpdateCatalogItemCommandHandler(
    ICatalogItemRepository catalogItemRepository,
    IBrandRepository brandRepository,
    ICategoryRepository categoryRepository) : ICommandHandler<UpdateCatalogItemCommand>
{
    public async Task<Unit> Handle(UpdateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var item = await catalogItemRepository.GetByIdAsync(command.Id, cancellationToken);

        if (item is null)
            throw new NotFoundException(nameof(CatalogItem), command.Id);

        await ApplyChangesAsync(item, command.UpdateCatalogItemDto, cancellationToken);
        
        await catalogItemRepository.UpdateAsync(item, cancellationToken);
        
        return default;
    }
    
    private async Task ApplyChangesAsync(CatalogItem item, UpdateCatalogItemDto updateData, CancellationToken cancellationToken)
    {
        var (title, description, brandName, categoryName, price) = updateData;

        if (brandName is not null)
        {
            var brand = await brandRepository.GetByNameAsync(brandName, cancellationToken)
                        ?? throw new NotFoundException(nameof(Brand), brandName);
            
            item.ChangeBrand(brand.Id);
        }

        if (categoryName is not null)
        {
            var category = await categoryRepository.GetByNameAsync(categoryName, cancellationToken)
                           ?? throw new NotFoundException(nameof(Category), categoryName);
            
            item.ChangeCategory(category.Id);
        }
        
        if (title is not null)
            item.ChangeTitle(title);

        if (description is not null)
            item.ChangeDescription(description);

        if (price.HasValue)
            item.ChangeUnitPrice(price.Value);
    }
}