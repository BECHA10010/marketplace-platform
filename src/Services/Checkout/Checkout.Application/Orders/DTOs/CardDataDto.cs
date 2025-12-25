namespace Checkout.Application.Orders.DTOs;

public record CardDataDto(string CardNumber, string Expiration, string CvvCode);