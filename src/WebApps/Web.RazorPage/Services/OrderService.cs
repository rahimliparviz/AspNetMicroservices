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
            var a =await _client.GetJsonAsync<List<OrderResponse>>($"/Order/{userName}");
            return a;
            // try
            // {
            //      var a =await _client.GetJsonAsync<List<OrderResponse>>($"/Order/{userName}");
            //      return a;
            // }
            // catch (Exception e)
            // {
            //     return new List<OrderResponse>();
            // }
           
            // var response = await _client.GetAsync($"/Order/{userName}");
            // return await response.ReadContentAs<List<OrderResponse>>();
        }
    }
}