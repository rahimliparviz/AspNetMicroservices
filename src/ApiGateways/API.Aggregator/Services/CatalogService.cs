using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using API.Aggregator.Models;
using Microsoft.AspNetCore.Components;

namespace API.Aggregator.Services
{
    public class CatalogService:ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<CatalogDto>> GetCatalog()
        {
            return await _client.GetJsonAsync<IEnumerable<CatalogDto>>("/api/v1/Catalog");
        }

        public async Task<CatalogDto> GetCatalog(string id)
        {
            return await _client.GetJsonAsync<CatalogDto>($"/api/v1/Catalog/{id}");
        }

        public async Task<IEnumerable<CatalogDto>> GetCatalogByCategory(string category)
        {
            return await _client.GetJsonAsync<IEnumerable<CatalogDto>>($"/api/v1/Catalog/GetProductByCategory/{category}");
        }
    }
}
