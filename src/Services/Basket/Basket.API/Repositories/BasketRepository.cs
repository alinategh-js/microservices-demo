using Basket.API.Models.Entities;
using Basket.API.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }
        public async Task<ShoppingCart?> GetBasket(string username)
        {
            var basketJson = await _redisCache.GetStringAsync(username);

            if (string.IsNullOrEmpty(basketJson))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basketJson);
        }

        public async Task<ShoppingCart?> UpdateBasket(ShoppingCart basket)
        {
            var basketJson = JsonConvert.SerializeObject(basket);
            await _redisCache.SetStringAsync(basket.Username, basketJson);
            return await GetBasket(basket.Username);
        }

        public async Task DeleteBasket(string username)
        {
            await _redisCache.RemoveAsync(username);
        }
    }
}
