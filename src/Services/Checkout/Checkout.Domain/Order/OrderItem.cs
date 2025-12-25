namespace Checkout.Domain.Order;

public record OrderItem(string ProductName, int Quantity, decimal UnitPrice);