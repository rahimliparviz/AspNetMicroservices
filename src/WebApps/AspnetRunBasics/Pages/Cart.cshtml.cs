using System;
using System.Linq;
using System.Threading.Tasks;
using Web.RazorPage.Models;
using Web.RazorPage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.RazorPage.Pages
{
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;

        public CartModel(IBasketService basketService)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public Basket Cart { get; set; } = new Basket();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "user";
            Cart = await _basketService.GetBasket(userName);

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var userName = "user";
            var basket = await _basketService.GetBasket(userName);

            var item = basket.Items.Single(x => x.ProductId == productId);
            basket.Items.Remove(item);

            await _basketService.UpdateBasket(basket);

            return RedirectToPage();
        }
    }
}