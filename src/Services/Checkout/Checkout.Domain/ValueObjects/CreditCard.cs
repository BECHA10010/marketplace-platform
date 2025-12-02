namespace Checkout.Domain.ValueObjects;

public record CreditCard(string CardNumber, string Expiration, string CvvCode);