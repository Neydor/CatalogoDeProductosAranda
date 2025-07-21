using Aranda.Productos.Domain.Entities;
using System.Threading.Tasks;

namespace Aranda.Productos.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByIdAsync(int id);
    }
}
