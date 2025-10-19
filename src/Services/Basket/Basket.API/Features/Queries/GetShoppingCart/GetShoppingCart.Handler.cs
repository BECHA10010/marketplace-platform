namespace Basket.API.Features.Queries.GetShoppingCart;

public static partial class GetShoppingCart
{
    public class Handler(IShoppingCartRepository repository) : IQueryHandler<GetShoppingCartQuery, GetShoppingCartResponse>
    {
        public async Task<GetShoppingCartResponse> Handle(GetShoppingCartQuery query, CancellationToken cancellationToken)
        {
            var cart = await repository.GetAsync(query.AccountName, cancellationToken);
            
            return new GetShoppingCartResponse(cart);
        }
    }
}