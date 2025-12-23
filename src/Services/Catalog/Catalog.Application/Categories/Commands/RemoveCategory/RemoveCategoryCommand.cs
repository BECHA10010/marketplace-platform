namespace Catalog.Application.Categories.Commands.RemoveCategory;

public record RemoveCategoryCommand(Guid Id) : ICommand;