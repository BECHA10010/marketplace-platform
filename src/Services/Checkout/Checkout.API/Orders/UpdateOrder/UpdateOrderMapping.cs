using Checkout.Application.Orders.Commands.UpdateOrder;
using Checkout.Domain.Order;

namespace Checkout.API.Orders.UpdateOrder;

public class UpdateOrderMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateOrderRequest, UpdateOrderDto>()
            .IgnoreNullValues(true)
            .Map(dest => dest.PaymentMethod, src => src.PaymentMethod == null 
                ? (PaymentMethod?)null 
                : Enum.Parse<PaymentMethod>(src.PaymentMethod)
            );
    }
}