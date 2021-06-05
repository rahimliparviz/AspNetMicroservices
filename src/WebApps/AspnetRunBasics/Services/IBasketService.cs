using System.Threading.Tasks;
using Web.RazorPage.Models;

namespace Web.RazorPage.Services
{
    public interface IBasketService
    {
        Task<Basket> GetBasket(string userName);
        Task<Basket> UpdateBasket(Basket model);
        Task CheckoutBasket(BasketCheckout model);
    }
}