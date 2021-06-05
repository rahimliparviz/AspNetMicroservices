using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web.RazorPage.Models;
using Microsoft.AspNetCore.Components;

namespace Web.RazorPage.Services
{
    public class CatalogService: ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client ;
        }

        public async Task<IEnumerable<Catalog>> GetCatalog()
        {
            return await _client.GetJsonAsync<List<Catalog>>("/Catalog");
            // var response = await _client.GetAsync("/Catalog");
            // return await response.ReadContentAs<List<Catalog>>();
        }

        public async Task<Catalog> GetCatalog(string id)
        {
            return await _client.GetJsonAsync<Catalog>($"/Catalog/{id}");
            // var response = await _client.GetAsync($"/Catalog/{id}");
            // return await response.ReadContentAs<Catalog>();
        }

        public async Task<IEnumerable<Catalog>> GetCatalogByCategory(string category)
        {
            return await _client.GetJsonAsync<List<Catalog>>($"/Catalog/GetProductByCategory/{category}");
            // var response = await _client.GetAsync($"/Catalog/GetProductByCategory/{category}");
            // return await response.ReadContentAs<List<Catalog>>();
        }

        public async Task<Catalog> CreateCatalog(Catalog model)
        {
            try
            {
                return await _client.PostJsonAsync<Catalog>($"/Catalog", model);
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong when calling api.");
            }
            // var response = await _client.PostAsJson($"/Catalog", model);
            // if (response.IsSuccessStatusCode)
            //     return await response.ReadContentAs<Catalog>();
            // else
            // {
            //     throw new Exception("Something went wrong when calling api.");
            // }
        }
    }
}