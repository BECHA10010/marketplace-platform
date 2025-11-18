namespace Checkout.Application.Queries.Orders.GetOrdersByAccountName;

public record GetOrdersByAccountNameQuery(string AccountName) : IQuery<GetOrdersByAccountNameResult>;