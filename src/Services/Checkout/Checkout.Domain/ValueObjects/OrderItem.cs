namespace Checkout.Domain.ValueObjects;

public record OrderItem(string ProductName, int Quantity, decimal UnitPrice);