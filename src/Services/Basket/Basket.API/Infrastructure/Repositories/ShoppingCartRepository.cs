namespace Basket.API.Infrastructure.Repositories;

public class ShoppingCartRepository(IDocumentSession session) : IShoppingCartRepository
{
    public async Task<ShoppingCart> GetAsync(string accountName, CancellationToken ct)
    {
        var cart = await session.LoadAsync<ShoppingCart>(accountName, ct);

        if (cart is null)
            throw new CartNotFoundException(accountName);

        return cart;
    }

    public async Task AddAsync(ShoppingCart cart, CancellationToken ct)
    {
        var existing = await session.LoadAsync<ShoppingCart>(cart.AccountName, ct);

        if (existing is not null)
            throw new CartAlreadyExistException(cart.AccountName);
        
        session.Store(cart);
        await session.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(string accountName, CancellationToken ct)
    {
        var cart = await session.LoadAsync<ShoppingCart>(accountName, ct);

        if (cart is null)
            throw new CartNotFoundException(accountName);
        
        session.Delete<ShoppingCart>(accountName);
        await session.SaveChangesAsync(ct);
    }
}