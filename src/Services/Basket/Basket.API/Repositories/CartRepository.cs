using Basket.API.Models.Entities;
using Basket.API.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IDistributedCache _redisCache;

        public CartRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }
        public async Task<ShoppingCart?> GetCart(string username)
        {
            var basketJson = await _redisCache.GetStringAsync(username);

            if (string.IsNullOrEmpty(basketJson))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basketJson);
        }

        public async Task<ShoppingCart?> UpdateCart(ShoppingCart basket)
        {
            var basketJson = JsonConvert.SerializeObject(basket);
            await _redisCache.SetStringAsync(basket.Username, basketJson);
            return await GetCart(basket.Username);
        }

        public async Task DeleteCart(string username)
        {
            await _redisCache.RemoveAsync(username);
        }
    }
}
