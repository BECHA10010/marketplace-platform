namespace Checkout.Application.Features.Orders.GetOrdersByAccountName;

public record GetOrdersByAccountNameQuery(string AccountName) : IQuery<GetOrdersByAccountNameResult>;