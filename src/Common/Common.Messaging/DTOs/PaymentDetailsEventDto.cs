namespace Common.Messaging.DTOs;

public record PaymentDetailsEventDto(string Method, string? CardNumber, string? Expiration, string? CvvCode);