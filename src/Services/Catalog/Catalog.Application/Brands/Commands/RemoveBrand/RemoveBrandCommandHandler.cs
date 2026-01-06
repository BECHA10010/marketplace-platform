namespace Catalog.Application.Brands.Commands.RemoveBrand;

public class RemoveBrandCommandHandler(IBrandRepository repository) : ICommandHandler<RemoveBrandCommand>
{
    public async Task<Unit> Handle(RemoveBrandCommand command, CancellationToken cancellationToken)
    {
        var id = command.Id;
        var brand = await repository.GetByIdAsync(id, cancellationToken);

        if (brand is null)
            throw new NotFoundException(nameof(Brand), id);
        
        await repository.DeleteAsync(brand, cancellationToken);
        return default;
    }
}