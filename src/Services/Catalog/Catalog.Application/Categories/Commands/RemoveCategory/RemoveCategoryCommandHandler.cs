namespace Catalog.Application.Categories.Commands.RemoveCategory;

public class RemoveCategoryCommandHandler(ICategoryRepository repository) : ICommandHandler<RemoveCategoryCommand>
{
    public async Task<Unit> Handle(RemoveCategoryCommand command, CancellationToken cancellationToken)
    {
        var id = command.Id;
        var category = await repository.GetByIdAsync(id, cancellationToken);

        if (category is null)
            throw new NotFoundException(nameof(Category), id);
        
        await repository.DeleteAsync(category, cancellationToken);
        return default;
    }
}