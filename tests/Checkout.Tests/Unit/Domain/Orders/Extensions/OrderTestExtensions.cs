using Checkout.Domain.Order;

namespace Checkout.Tests.Unit.Domain.Orders.Extensions;

public static class OrderTestExtensions
{
    public static void SetOrderStatus(this Order order, OrderStatus status)
    {
        typeof(Order)
            .GetProperty(nameof(Order.Status))!
            .SetValue(order, status);
    }
}