namespace Checkout.API.Features.Orders.Common.Requests;

public record CardDataRequest(string CardNumber, string Expiration, string CvvCode);