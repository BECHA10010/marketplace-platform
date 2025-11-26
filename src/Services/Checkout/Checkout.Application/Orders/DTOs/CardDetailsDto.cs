namespace Checkout.Application.Orders.DTOs;

public record CardDetailsDto(string CardName, string CardNumber, string Expiration, string CvvCode);