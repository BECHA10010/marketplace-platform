using Checkout.Application.Orders.Commands.UpdateOrder.DTOs;

namespace Checkout.API.Features.Orders.UpdateOrder;

public record UpdateOrderRequest(UpdateOrderDto UpdateData);