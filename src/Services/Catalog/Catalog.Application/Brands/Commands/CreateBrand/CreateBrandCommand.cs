namespace Catalog.Application.Brands.Commands.CreateBrand;

public record CreateBrandCommand(CreateBrandDto CreateDto) : ICommand<CreateBrandResult>;