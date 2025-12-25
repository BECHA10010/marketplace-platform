namespace Checkout.API.Orders.Common.Requests;

public record CardDataRequest(string CardNumber, string Expiration, string CvvCode);