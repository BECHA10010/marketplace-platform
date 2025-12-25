namespace Checkout.Domain.Order;

public record CreditCard(string CardNumber, string Expiration, string CvvCode);