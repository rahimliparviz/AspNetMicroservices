using System;
using System.Net.Http;
using System.Threading.Tasks;
using Web.RazorPage.Models;
using Microsoft.AspNetCore.Components;
using Web.RazorPage.Extensions;
using Web.RazorPage.Models;

namespace Web.RazorPage.Services
{
    public class BasketService:IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Basket> GetBasket(string userName)
        {
            return await _client.GetJsonAsync<Basket>($"/Basket/{userName}");
            // var response = await _client.GetAsync($"/Basket/{userName}");
            // return await response.ReadContentAs<Basket>();
        }

        public async Task<Basket> UpdateBasket(Basket model)
        {
            try
            {
                return await _client.PostJsonAsync<Basket>($"/Basket", model);
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong when calling api.");
            }
            
            
            // var response = await _client.PostAsJson($"/Basket", model);
            // if (response.IsSuccessStatusCode)
            //     return await response.ReadContentAs<Basket>();
            // else
            // {
            //     throw new Exception("Something went wrong when calling api.");
            // }
        }

        public async Task CheckoutBasket(BasketCheckout model)
        {
      
            var response = await _client.PostAsJson($"/Basket/Checkout", model);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}