namespace Basket.API.Domain.Entities;

public class ShoppingCart : IAggregateRoot
{
    private readonly List<CartItem> _items = [];
    
    public Guid Id { get; private set; }
    public string AccountName { get; private set; } = default!;
    
    public decimal TotalAmount => _items.Sum(i => i.FinalPrice);
    public decimal TotalDiscount => _items.Sum(i => i.Discount * i.Quantity);
    
    public IReadOnlyList<CartItem> Items => _items.AsReadOnly();
    
    private ShoppingCart() { }
    
    private ShoppingCart(string accountName)
    {
        Id = Guid.NewGuid();
        AccountName = accountName;
    }
    
    public static ShoppingCart Create(string accountName) => new (accountName);
    
    public void AddItem(Guid catalogItemId, string title, int quantity, decimal unitPrice)
    {
        var item = _items.FirstOrDefault(i => i.CatalogItemId == catalogItemId);

        if (item is null)
            _items.Add(CartItem.Create(catalogItemId, title, quantity, unitPrice));
        else
            item.IncreaseQuantity(quantity);
    }
    
    public void ApplyDiscountForItem(Guid catalogItemId, decimal discount)
    {
        var item = _items.FirstOrDefault(i => i.CatalogItemId == catalogItemId)
            ?? throw new DomainException($"Item {catalogItemId} not found in cart");
        
        item.ApplyDiscount(discount);
    }
    
    public void Clear() => _items.Clear();
}