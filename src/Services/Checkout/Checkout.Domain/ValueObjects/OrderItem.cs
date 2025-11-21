namespace Checkout.Domain.ValueObjects;

public record OrderItem(int Id, string CatalogItemName, int Quantity, decimal UnitPrice);