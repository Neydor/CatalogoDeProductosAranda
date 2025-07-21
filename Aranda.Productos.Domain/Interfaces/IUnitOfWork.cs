using System;
using System.Threading.Tasks;

namespace Aranda.Productos.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        Task<int> SaveChangesAsync();
    }
} 