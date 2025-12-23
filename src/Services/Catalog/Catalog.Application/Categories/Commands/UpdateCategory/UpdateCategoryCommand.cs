namespace Catalog.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(Guid Id, UpdateCategoryDto UpdateDto) : ICommand;