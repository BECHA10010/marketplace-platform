namespace Basket.API.Infrastructure.Entities;

public class ShoppingCartEntity
{
    public Guid Id { get; set; }
    public string AccountName { get; set; } = default!;
    public required List<ShoppingCartItemEntity> Items { get; set; } = [];
}