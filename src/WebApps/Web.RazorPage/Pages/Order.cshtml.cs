using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.RazorPage.Models;
using Web.RazorPage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.RazorPage.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IOrderService _orderService;

        public OrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IEnumerable<OrderResponse> Orders { get; set; } = new List<OrderResponse>();

        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await _orderService.GetOrdersByUserName("user");

            return Page();
        }       
    }
}