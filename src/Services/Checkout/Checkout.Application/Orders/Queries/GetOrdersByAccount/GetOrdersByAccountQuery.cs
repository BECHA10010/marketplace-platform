namespace Checkout.Application.Orders.Queries.GetOrdersByAccount;

public record GetOrdersByAccountQuery(string AccountName) : IQuery<GetOrdersByAccountResult>;