using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Wrappers
{
    public class RedisWrapper:IRedisWrapper
    {
        private readonly IDistributedCache _redisCache;
        public RedisWrapper(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }
        public async Task<string> GetStringAsync(string userName)
        {
           return await _redisCache.GetStringAsync(userName);
        }

        public async Task RemoveAsync(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task SetStringAsync(string userName, object obj)
        {
            await _redisCache.SetStringAsync(userName, JsonConvert.SerializeObject(obj));
        }
    }
}