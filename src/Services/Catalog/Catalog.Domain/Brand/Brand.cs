namespace Catalog.Domain.Brand;

public class Brand : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;

    private Brand() { }

    private Brand(string name)
    {
        SetName(name);
    }

    private Brand(Guid id, string name) : this(name)
    {
        Id = id;
    }
    
    public static Brand Create(string name) => new(name);
    public static Brand Create(Guid id, string name) => new(id, name);
    
    public void ChangeName(string newName) => SetName(newName);
    
    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Brand name cannot be empty");

        if (name.Length > 50)
            throw new DomainException("Brand name length must be <= 50");

        Name = name;
    }
}