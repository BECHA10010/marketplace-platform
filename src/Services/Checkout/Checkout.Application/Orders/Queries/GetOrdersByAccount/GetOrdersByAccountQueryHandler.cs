namespace Checkout.Application.Orders.Queries.GetOrdersByAccount;

public class GetOrdersByAccountQueryHandler(IOrderRepository repository)
    : IQueryHandler<GetOrdersByAccountQuery, GetOrdersByAccountResult>
{
    public async Task<GetOrdersByAccountResult> Handle(GetOrdersByAccountQuery query, CancellationToken ct)
    {
        var orders = await repository.GetByAccountName(query.AccountName, ct);
        
        return new GetOrdersByAccountResult(orders.Adapt<List<OrderDto>>());
    }
}