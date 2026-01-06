namespace Checkout.Application.Orders.Queries.GetOrdersByAccount;

public class GetOrdersByAccountMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Order, OrderDto>()
            .Map(dest => dest.Status, src => src.Status.ToString())
            .Map(dest => dest.PaymentMethod, src => src.PaymentMethod.ToString())
            .Map(dest => dest.PaymentStatus, src => src.PaymentStatus.ToString())
            .Map(dest => dest.Address, src => src.DeliveryAddress);

        config.NewConfig<OrderItem, OrderItemDto>();
        config.NewConfig<DeliveryAddress, CustomerAddressDto>();
    }
}