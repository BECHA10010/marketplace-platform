namespace Catalog.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(ICategoryRepository repository) 
    : ICommandHandler<CreateCategoryCommand, CreateCategoryResult>
{
    public async Task<CreateCategoryResult> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var name = command.CreateDto.Name;
        var existing = await repository.GetByNameAsync(name, cancellationToken);
        
        if (existing is not null)
            throw new AlreadyExistException(nameof(Category), name);

        var newCategory = Category.Create(name);
        await repository.AddAsync(newCategory, cancellationToken);

        return new CreateCategoryResult(newCategory.Id);
    }
}