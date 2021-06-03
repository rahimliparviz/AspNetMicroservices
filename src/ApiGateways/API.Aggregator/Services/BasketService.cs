using API.Aggregator.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using API.Aggregator.Extensions;

namespace API.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<BasketDto> GetBasket(string userName)
        {
            var basket =  await _client.GetJsonAsync<BasketDto>($"/api/v1/Basket/{userName}");
            return basket;
        }
    }
}
