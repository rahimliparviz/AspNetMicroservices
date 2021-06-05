using System.Collections.Generic;
using System.Threading.Tasks;
using Web.RazorPage.Models;

namespace Web.RazorPage.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<Catalog>> GetCatalog();
        Task<IEnumerable<Catalog>> GetCatalogByCategory(string category);
        Task<Catalog> GetCatalog(string id);
        Task<Catalog> CreateCatalog(Catalog model);
    }
}