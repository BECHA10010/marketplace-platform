namespace Checkout.Application.DTOs.ValueObjects;

public record PaymentDetailsDto(string CardName, string MaskedCardNumber, string Expiration);