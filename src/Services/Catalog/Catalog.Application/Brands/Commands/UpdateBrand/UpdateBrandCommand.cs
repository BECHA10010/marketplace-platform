namespace Catalog.Application.Brands.Commands.UpdateBrand;

public record UpdateBrandCommand(Guid Id, UpdateBrandDto UpdateDto) : ICommand;