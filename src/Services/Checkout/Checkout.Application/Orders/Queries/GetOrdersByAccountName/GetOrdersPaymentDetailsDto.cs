namespace Checkout.Application.Orders.Queries.GetOrdersByAccountName;

public record GetOrdersPaymentDetailsDto(string CardName, string MaskedCardNumber, string Expiration);