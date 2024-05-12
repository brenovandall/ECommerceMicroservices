namespace Basket.API;

public interface IBasketRepository
{
    public Task<ShoppingCart> GetBasket(string Username, CancellationToken cancellationToken = default(CancellationToken));
    public Task<ShoppingCart> StoreBasket(ShoppingCart Basket, CancellationToken cancellationToken = default(CancellationToken));
    public Task<bool> DeleteBasket(string Username, CancellationToken cancellationToken = default(CancellationToken));
}
