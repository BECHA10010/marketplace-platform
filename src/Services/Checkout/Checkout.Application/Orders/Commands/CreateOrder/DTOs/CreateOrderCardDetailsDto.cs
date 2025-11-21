namespace Checkout.Application.Orders.Commands.CreateOrder.DTOs;

public record CreateOrderCardDetailsDto(string CardName, string CardNumber, string Expiration, string CvvCode);