namespace Catalog.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(CreateCategoryDto CreateDto) : ICommand<CreateCategoryResult>;