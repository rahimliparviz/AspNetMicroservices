using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Basket.API.Wrappers;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        // private readonly IDistributedCache _redisCache;
        private readonly IRedisWrapper _redisCache;

        public BasketRepository(IRedisWrapper redisCache)
        {
            _redisCache = redisCache;
        }

      
        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(basket)) return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        
        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _redisCache.SetStringAsync(basket.UserName, basket);
            return  await GetBasket(basket.UserName);
          
        }
    }
}
