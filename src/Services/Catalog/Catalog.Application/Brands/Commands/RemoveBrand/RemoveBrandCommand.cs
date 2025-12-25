namespace Catalog.Application.Brands.Commands.RemoveBrand;

public record RemoveBrandCommand(Guid Id) : ICommand;