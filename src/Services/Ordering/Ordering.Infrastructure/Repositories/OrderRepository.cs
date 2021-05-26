using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Repositories;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository:RepositoryBase<Order>,IOrderRepository
    {
        //Burda biz dependency injection kimi IOrderRepository toruni secsek
        //ve OrderRepository obyektini yaratsaq OrderReponun contructorunda
        //qeyd etdiyimiz diger dependencilerid base classina gondermeliyik
        public OrderRepository(OrderContext dbContext) : base(dbContext){}

        public async Task<IReadOnlyList<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                .Where(o => o.UserName == userName)
                .ToListAsync();
            return orderList;
        }
    }
}