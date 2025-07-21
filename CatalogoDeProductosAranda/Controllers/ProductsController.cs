using Aranda.Productos.Application.DTOs;
using Aranda.Productos.Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogoDeProductosAranda.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        /// <summary>
        /// Obtiene una lista paginada y filtrada de productos.
        /// </summary>
        /// <param name="queryParameters">Parámetros de consulta para filtrar, ordenar y paginar.</param>
        /// <returns>Una respuesta paginada con la lista de productos y metadatos de paginación.</returns>
        [HttpGet]
        [Route("")] // Corresponde a GET /api/products?filter=...&sortBy=...
        public async Task<IHttpActionResult> GetProducts([FromUri] ProductQueryParameters queryParameters)
        {
            if (queryParameters == null)
            {
                // Si los parámetros son nulos, inicializamos con valores por defecto.
                queryParameters = new ProductQueryParameters();
            }

            var pagedResult = await _productService.GetProductsAsync(queryParameters);
            return Ok(pagedResult);
        }

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto.</param>
        /// <returns>El producto encontrado o un 404 Not Found.</returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetProductById")] // Corresponde a GET /api/products/5
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(); // Retorna un código 404
            }
            return Ok(product);
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="productDto">El producto a crear desde el cuerpo de la petición.</param>
        /// <returns>Un 201 Created con la ubicación del nuevo recurso y el producto creado.</returns>
        [HttpPost]
        [Route("")] // Corresponde a POST /api/products
        public async Task<IHttpActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna un 400 con los errores de validación
            }

            try
            {
                var createdProduct = await _productService.AddProductAsync(productDto);
                return CreatedAtRoute("GetProductById", new { id = createdProduct.Id }, createdProduct);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="id">El ID del producto a actualizar.</param>
        /// <param name="productDto">Los datos actualizados del producto.</param>
        /// <returns>Un 204 No Content si fue exitoso, o 400/404 si hubo un error.</returns>
        [HttpPut]
        [Route("{id:int}")] // Corresponde a PUT /api/products/5
        public async Task<IHttpActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _productService.UpdateProductAsync(id, productDto);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException)
            {
                // El servicio lanza esta excepción si no encuentra el producto.
                return NotFound();
            }
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar.</param>
        /// <returns>Un 204 No Content si fue exitoso, o 404 si no se encontró.</returns>
        [HttpDelete]
        [Route("{id:int}")] // Corresponde a DELETE /api/products/5
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
            }
            catch (KeyNotFoundException)
            {
                // Si el producto a eliminar no existe, es idempotente, pero podemos devolver 404 para ser más informativos.
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent); // Retorna 204 No Content.
        }
    }
}
