using Aranda.Productos.Domain.Entities;
using Aranda.Productos.Domain.Interfaces;
using Aranda.Productos.Infrastructure.Persistence;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Aranda.Productos.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
