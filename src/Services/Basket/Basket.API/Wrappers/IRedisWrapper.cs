using System.Threading.Tasks;

namespace Basket.API.Wrappers
{
    public interface IRedisWrapper
    {
        Task<string> GetStringAsync(string userName);
        Task RemoveAsync(string userName);
        Task SetStringAsync(string userName,object obj);
    }
}