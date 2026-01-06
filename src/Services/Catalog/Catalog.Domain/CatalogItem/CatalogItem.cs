using Common.Kernel.Domain.Abstractions;

namespace Catalog.Domain.CatalogItem;

public class CatalogItem : BaseEntity, IAggregateRoot
{
    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public Guid BrandId { get; private set; }
    public Guid CategoryId { get; private set; }
    public decimal UnitPrice { get; private set; }

    private CatalogItem() { }

    private CatalogItem(string title, string description, Guid brandId, Guid categoryId, decimal unitPrice)
    {
        SetTitle(title);
        SetDescription(description);
        SetBrand(brandId);
        SetCategory(categoryId);
        SetUnitPrice(unitPrice);
    }

    private CatalogItem(Guid id, string title, string description, Guid brandId, Guid categoryId, decimal unitPrice)
        : this(title, description, brandId, categoryId, unitPrice)
    {
        Id = id;
    }

    public static CatalogItem Create(string title, string description, Guid brandId, Guid categoryId, decimal unitPrice)
        => new (title, description, brandId, categoryId, unitPrice);
    
    public static CatalogItem Create(Guid id, string title, string description, Guid brandId, Guid categoryId, decimal unitPrice)
        => new (id, title, description, brandId, categoryId, unitPrice);
    
    public void ChangeTitle(string newTitle) => SetTitle(newTitle);
    
    public void ChangeDescription(string newDescription) => SetDescription(newDescription);
    
    public void ChangeBrand(Guid newBrandId) => SetBrand(newBrandId);
    
    public void ChangeCategory(Guid newCategoryId) => SetCategory(newCategoryId);
    
    public void ChangeUnitPrice(decimal newUnitPrice) => SetUnitPrice(newUnitPrice);
    
    private void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title cannot be empty");

        Title = title;
    }

    private void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Description cannot be empty");

        Description = description;
    }

    private void SetBrand(Guid brandId)
    {
        if (brandId == Guid.Empty)
            throw new DomainException("BrandId is invalid");

        BrandId = brandId;
    }

    private void SetCategory(Guid categoryId)
    {
        if (categoryId == Guid.Empty)
            throw new DomainException("CategoryId is invalid");

        CategoryId = categoryId;
    }

    private void SetUnitPrice(decimal price)
    {
        if (price <= 0)
            throw new DomainException("Price must be greater than zero");

        UnitPrice = price;
    }
}