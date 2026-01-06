namespace Checkout.Domain.Order;

public record OrderItem(string Title, int Quantity, decimal UnitPrice);