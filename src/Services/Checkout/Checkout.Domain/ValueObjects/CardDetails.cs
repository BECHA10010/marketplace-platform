namespace Checkout.Domain.ValueObjects;

public record CardDetails(string CardNumber, string Expiration, string CvvCode);