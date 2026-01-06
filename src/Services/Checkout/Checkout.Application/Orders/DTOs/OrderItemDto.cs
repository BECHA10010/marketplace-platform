namespace Checkout.Application.Orders.DTOs;

public record OrderItemDto(string Title, int Quantity, decimal UnitPrice);