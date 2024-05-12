namespace Basket.API;

public class CachedBasketRepository(IBasketRepository _repository, IDistributedCache _cache) 
    : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string Username, CancellationToken cancellationToken = default)
    {
        var cached = await _cache.GetStringAsync(Username, cancellationToken);

        if(!string.IsNullOrEmpty(cached))
            return JsonSerializer.Deserialize<ShoppingCart>(cached)!;

        var basket = await _repository.GetBasket(Username, cancellationToken);

        await _cache.SetStringAsync(Username, JsonSerializer.Serialize(basket), cancellationToken);

        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart Basket, CancellationToken cancellationToken = default)
    {
        await _repository.StoreBasket(Basket, cancellationToken);

        await _cache.SetStringAsync(Basket.Username, JsonSerializer.Serialize(Basket), cancellationToken);

        return Basket;
    }

    public async Task<bool> DeleteBasket(string Username, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteBasket(Username, cancellationToken);

        await _cache.RemoveAsync(Username, cancellationToken);

        return true;
    }
}
