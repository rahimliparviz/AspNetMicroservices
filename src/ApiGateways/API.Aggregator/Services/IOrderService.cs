using API.Aggregator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Aggregator.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);

    }
}
