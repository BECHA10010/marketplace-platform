namespace Checkout.Application.Orders.Queries.GetOrdersByAccountName;

public class GetOrdersByAccountNameHandler(IOrderRepository repository)
    : IQueryHandler<GetOrdersByAccountNameQuery, GetOrdersByAccountNameResult>
{
    public async Task<GetOrdersByAccountNameResult> Handle(GetOrdersByAccountNameQuery query, CancellationToken ct)
    {
        var orders = await repository.GetOrdersByAccountName(query.AccountName);

        return new GetOrdersByAccountNameResult(orders); //.Adapt<IEnumerable<OrderDto>>());
    }
}