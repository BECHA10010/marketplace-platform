namespace Promotion.Grpc.Domain.Promo;

public class Promo
{
    public Guid Id { get; set; }
    public string? CatalogItemId { get; set; }
    public string Description { get; set; } = default!;
    public decimal Value { get; set; }
}