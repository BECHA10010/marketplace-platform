namespace Basket.API.Features.Queries.GetShoppingCart;

public static partial class GetShoppingCart
{
    public class Handler(IShoppingCartRepository repository) : IQueryHandler<Query, Response>
    {
        public async Task<Response> Handle(Query query, CancellationToken cancellationToken)
        {
            var cart = await repository.GetAsync(query.AccountName, cancellationToken);
            
            return new Response(cart);
        }
    }
}