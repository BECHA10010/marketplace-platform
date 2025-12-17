namespace Basket.API.Domain.Entities;

public class CartItem
{
    public Guid CatalogItemId { get; private set; }
    public string Title { get; private set; } = default!;
    public int Quantity { get; private set; }
    
    public decimal UnitPrice { get; private set; }
    public decimal Discount { get; private set; }
    
    public decimal FinalPrice => (UnitPrice - Discount) * Quantity;
    
    private CartItem() { }

    private CartItem(Guid catalogItemId, string title, int quantity, decimal unitPrice)
    {
        CatalogItemId = catalogItemId;
        Title = title;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = 0;
    }

    public static CartItem Create(Guid catalogItemId, string title, int quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new DomainException("Quantity must be positive");
        if (unitPrice <= 0) throw new DomainException("UnitPrice must be positive");

        return new CartItem(catalogItemId, title, quantity, unitPrice);
    }

    public void IncreaseQuantity(int quantity)
    {
        if (quantity <= 0) throw new DomainException("Quantity must be positive");
        Quantity += quantity;
    }

    public void ApplyDiscount(decimal discount)
    {
        if (discount < 0) return;
        if (discount > UnitPrice) throw new DomainException("Invalid discount");

        Discount = discount;
    }
}