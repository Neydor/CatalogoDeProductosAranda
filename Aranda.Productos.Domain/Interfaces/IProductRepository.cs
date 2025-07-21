using Aranda.Productos.Domain.Entities;
using Aranda.Productos.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Aranda.Productos.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByIdAsync(int id);
        Task<PagedResult<Product>> GetAllAsync(string filter, string sort, int page, int pageSize);
    }
}
