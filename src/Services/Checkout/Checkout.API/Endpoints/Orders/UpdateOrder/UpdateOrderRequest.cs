using Checkout.Application.Orders.Commands.UpdateOrder.DTOs;

namespace Checkout.API.Endpoints.Orders.UpdateOrder;

public record UpdateOrderRequest(UpdateOrderDto UpdateData);