namespace Basket.API;

public class BasketRepository (IDocumentSession _session) : IBasketRepository
{
    public async Task<bool> DeleteBasket(string Username, CancellationToken cancellationToken = default)
    {
        _session.Delete<ShoppingCart>(Username);
        await _session.SaveChangesAsync();

        return true;
    }

    public async Task<ShoppingCart> GetBasket(string Username, CancellationToken cancellationToken = default)
    {
        var basket = await _session.LoadAsync<ShoppingCart>(Username, cancellationToken);

        return basket is null ? throw new BasketNotFoundException(Username) : basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart Basket, CancellationToken cancellationToken = default)
    {
        _session.Store<ShoppingCart>(Basket);
        await _session.SaveChangesAsync();
        
        return Basket;
    }
}
