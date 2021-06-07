using System.Threading.Tasks;
using Basket.API.Entities;

namespace Basket.API.Wrappers
{
    public interface IRedisWrapper
    {
        Task<string> GetStringAsync(string userName);
        Task RemoveAsync(string userName);
        Task SetStringAsync(string userName,ShoppingCart obj);
    }
}