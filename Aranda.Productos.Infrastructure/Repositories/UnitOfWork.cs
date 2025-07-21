using Aranda.Productos.Domain.Interfaces;
using Aranda.Productos.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace Aranda.Productos.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
} 