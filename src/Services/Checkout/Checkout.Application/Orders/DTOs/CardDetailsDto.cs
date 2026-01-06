namespace Checkout.Application.Orders.DTOs;

public record CardDetailsDto(string CardNumber, string Expiration, string CvvCode);