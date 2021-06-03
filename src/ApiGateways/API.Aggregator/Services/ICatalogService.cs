using API.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Aggregator.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogDto>> GetCatalog();
        Task<IEnumerable<CatalogDto>> GetCatalogByCategory(string category);
        Task<CatalogDto> GetCatalog(string id);
    }
}
