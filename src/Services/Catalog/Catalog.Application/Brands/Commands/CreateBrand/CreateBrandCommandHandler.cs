namespace Catalog.Application.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler(IBrandRepository repository) 
    : ICommandHandler<CreateBrandCommand, CreateBrandResult>
{
    public async Task<CreateBrandResult> Handle(CreateBrandCommand command, CancellationToken cancellationToken)
    {
        var name = command.CreateDto.Name;
        var existing = await repository.GetByNameAsync(name, cancellationToken);
        
        if (existing is not null)
            throw new AlreadyExistException(nameof(Brand), name);

        var newBrand = Brand.Create(name);
        await repository.AddAsync(newBrand, cancellationToken);

        return new CreateBrandResult(newBrand.Id);
    }
}