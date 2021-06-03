using API.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using API.Aggregator.Extensions;

namespace API.Aggregator.Services
{
    public class OrderService:IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            try
            {
                return await _client.GetJsonAsync<IEnumerable<OrderResponseModel>>($"/api/v1/Order/{userName}");

            }
            catch (Exception e)
            {
                return null;
            }
      
        }
    }
}
