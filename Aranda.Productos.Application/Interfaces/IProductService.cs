using Aranda.Productos.Application.DTOs;
using Aranda.Productos.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aranda.Productos.Application.Interfaces
{
    public interface IProductService
    {
        Task<PagedResponse<ProductDto>> GetProductsAsync(ProductQueryParameters queryParameters);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> AddProductAsync(CreateProductDto productDto);
        Task UpdateProductAsync(int id, UpdateProductDto productDto);
        Task DeleteProductAsync(int id);
    }
}
