using System.Threading.Tasks;
using Web.RazorPage.Models;
using Web.RazorPage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.RazorPage.Models;

namespace Web.RazorPage.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly IBasketService _basketService;

        public CheckOutModel(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [BindProperty]
        public BasketCheckout Order { get; set; }

        public Basket Cart { get; set; } = new Basket();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "user";
            Cart = await _basketService.GetBasket(userName);

            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var userName = "user";
            Cart = await _basketService.GetBasket(userName);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.UserName = userName;
            Order.TotalPrice = Cart.TotalPrice;

            await _basketService.CheckoutBasket(Order);
            
            return RedirectToPage("Confirmation", "OrderSubmitted");
        }       
    }
}