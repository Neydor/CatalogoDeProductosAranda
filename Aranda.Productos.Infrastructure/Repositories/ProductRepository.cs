using Aranda.Productos.Domain.Entities;
using Aranda.Productos.Domain.Interfaces;
using Aranda.Productos.Domain.ValueObjects;
using Aranda.Productos.Infrastructure.Persistence;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Aranda.Productos.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<PagedResult<Product>> GetAllAsync(string filter, string sort, int page, int pageSize)
        {
            var query = _context.Products.Include(p => p.Categoria).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(p => p.Nombre.Contains(filter) || p.Descripcion.Contains(filter) || p.Categoria.Nombre.Contains(filter));
            }

            if (!string.IsNullOrEmpty(sort))
            {
                query = ApplySort(query, sort);
            }

            var totalRecords = await query.CountAsync();
            var results = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<Product>(
                results,
                totalRecords
                );
        }

        private static IQueryable<Product> ApplySort(IQueryable<Product> query, string sort)
        {
            var sortParams = sort.Split(' ');
            var propertyName = sortParams[0];
            var sortDirection = sortParams.Length > 1 ? sortParams[1].ToLower() : "asc";

            switch (propertyName.ToLower())
            {
                case "categoria":
                    query = sortDirection == "asc" ? query.OrderBy(p => p.Categoria.Nombre) : query.OrderByDescending(p => p.Categoria.Nombre);
                    break;
                case "nombre":
                    query = sortDirection == "asc" ? query.OrderBy(p => p.Nombre) : query.OrderByDescending(p => p.Nombre);
                    break;
                default:
                    query = sortDirection == "asc" ? query.OrderBy(p => p.Nombre) : query.OrderByDescending(p => p.Nombre);
                    break;
            }

            return query;
        }

    }
}
