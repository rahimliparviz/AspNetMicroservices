using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web.RazorPage.Models;
using Microsoft.AspNetCore.Components;

namespace Web.RazorPage.Services
{
    public class OrderService:IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ;
        }

        public async Task<IEnumerable<OrderResponse>> GetOrdersByUserName(string userName)
        {
         return  await _client.GetJsonAsync<List<OrderResponse>>($"/Order/{userName}");
        }
    }
}