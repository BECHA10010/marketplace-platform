namespace Common.Messaging.DTOs;

public record OrderItemEventDto(string Title, int Quantity, decimal UnitPrice);