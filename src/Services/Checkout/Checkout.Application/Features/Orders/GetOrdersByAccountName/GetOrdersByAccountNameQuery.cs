namespace Checkout.Application.Orders.Queries.GetOrdersByAccountName;

public record GetOrdersByAccountNameQuery(string AccountName) : IQuery<GetOrdersByAccountNameResult>;