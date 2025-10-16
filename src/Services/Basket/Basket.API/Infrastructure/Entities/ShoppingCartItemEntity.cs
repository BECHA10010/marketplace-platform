namespace Basket.API.Infrastructure.Entities;

public class ShoppingCartItemEntity
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; } = default!;
    
    public Guid ShoppingCartId { get; set; }
    public required ShoppingCartEntity ShoppingCart { get; set; }
}