using Aranda.Productos.Application.DTOs;
using Aranda.Productos.Application.Interfaces;
using Aranda.Productos.Domain.Entities;
using Aranda.Productos.Domain.Interfaces;
using Aranda.Productos.Domain.ValueObjects;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aranda.Productos.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddProductAsync(CreateProductDto createProductDto)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(createProductDto.CategoriaId);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            var product = _mapper.Map<Product>(createProductDto);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            await _unitOfWork.Products.DeleteAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResponse<ProductDto>> GetProductsAsync(ProductQueryParameters queryParameters)
        {
            var sort = $"{queryParameters.SortBy} {queryParameters.SortOrder}";
            var pagedResult = await _unitOfWork.Products.GetAllAsync(
                queryParameters.Filter,
                sort,
                queryParameters.Page,
                queryParameters.PageSize);

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(pagedResult.Items);

            return new PagedResponse<ProductDto>(
                productDtos,
                pagedResult.TotalCount,
                queryParameters.Page,
                queryParameters.PageSize);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            return _mapper.Map<ProductDto>(product);
        }


        public async Task UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            var category = await _unitOfWork.Categories.GetByIdAsync(updateProductDto.CategoriaId);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            _mapper.Map(updateProductDto, existingProduct);
            await _unitOfWork.Products.UpdateAsync(existingProduct);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
