using Aranda.Productos.Domain.Interfaces;
using Aranda.Productos.Infrastructure.Persistence;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Aranda.Productos.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
} 