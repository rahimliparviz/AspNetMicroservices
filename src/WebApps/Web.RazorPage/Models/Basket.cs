using System.Collections.Generic;
using Web.RazorPage.Models;

namespace Web.RazorPage.Models
{
    public class Basket
    {
        public string UserName { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public decimal TotalPrice { get; set; }
    }
}