namespace Catalog.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler(ICategoryRepository repository) : ICommandHandler<UpdateCategoryCommand>
{
    public async Task<Unit> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var id = command.Id;
        var category = await repository.GetByIdAsync(id, cancellationToken);
        
        if (category is null)
            throw new NotFoundException(nameof(Category), id);
        
        category.ChangeName(command.UpdateDto.NewName);
        
        await repository.UpdateAsync(category, cancellationToken);
        return default;
    }
}