using Checkout.API.Orders.Common.Responses;

namespace Checkout.API.Orders.GetOrdersByAccount;

public record GetOrdersByAccountResponse(string AccountName, List<OrderResponse> Orders);