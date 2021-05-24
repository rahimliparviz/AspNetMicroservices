using System.Collections.Generic;
using System.Threading.Tasks;
using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Repositories
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IReadOnlyList<Order>> GetOrdersByUserName(string userName);
    }
}