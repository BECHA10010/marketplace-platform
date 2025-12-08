namespace Checkout.Application.Features.Orders.Common.DTOs;

public record CardDataDto(string CardNumber, string Expiration, string CvvCode);