namespace Catalog.Application.CatalogItems.Commands.CreateCatalogItem;

public class CreateCatalogItemCommandHandler(
    ICatalogItemRepository catalogItemRepository,
    IBrandRepository brandRepository,
    ICategoryRepository categoryRepository) : ICommandHandler<CreateCatalogItemCommand, CreateCatalogItemResult>
{
    public async Task<CreateCatalogItemResult> Handle(CreateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var data = command.CreateData;
        
        var existing = await catalogItemRepository.GetByTitleAsync(data.Title, cancellationToken);

        if (existing is not null)
            throw new AlreadyExistException("CatalogItem", data.Title);

        var brand = await brandRepository.GetByNameAsync(data.Brand, cancellationToken)
            ?? throw new NotFoundException(nameof(Brand), command.CreateData.Brand);

        var category = await categoryRepository.GetByNameAsync(data.Category, cancellationToken)
            ?? throw new NotFoundException(nameof(Category), data.Category);
        
        var catalogItem = CatalogItem.Create(data.Title, data.Description, brand.Id, category.Id, data.Price);

        await catalogItemRepository.AddAsync(catalogItem, cancellationToken);
        
        return new CreateCatalogItemResult(catalogItem.Id);
    }
}