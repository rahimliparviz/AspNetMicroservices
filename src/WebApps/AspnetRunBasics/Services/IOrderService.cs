using System.Collections.Generic;
using System.Threading.Tasks;
using Web.RazorPage.Models;

namespace Web.RazorPage.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponse>> GetOrdersByUserName(string userName);

    }
}