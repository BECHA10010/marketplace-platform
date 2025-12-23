namespace Catalog.Domain.Category;

public class Category : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;

    private Category() { }

    private Category(string name)
    {
        SetName(name);
    }
    
    private Category(Guid id, string name) : this(name)
    {
        Id = id;
    }
    
    public static Category Create(string title) => new(title);
    public static Category Create(Guid id, string title) => new(id, title);
    
    public void ChangeName(string newName) => SetName(newName);
    
    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Category name cannot be empty");

        if (name.Length > 50)
            throw new DomainException("Category name length must be <= 50");

        Name = name;
    }
}