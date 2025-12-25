namespace Catalog.Application.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandHandler(IBrandRepository repository) : ICommandHandler<UpdateBrandCommand>
{
    public async Task<Unit> Handle(UpdateBrandCommand command, CancellationToken cancellationToken)
    {
        var id = command.Id;
        var brand = await repository.GetByIdAsync(id, cancellationToken);
        
        if (brand is null)
            throw new NotFoundException(nameof(Brand), id);
        
        brand.ChangeName(command.UpdateDto.NewName);
        
        await repository.UpdateAsync(brand, cancellationToken);
        return default;
    }
}