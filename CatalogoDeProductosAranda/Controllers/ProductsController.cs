using CatalogoDeProductosAranda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalogoDeProductosAranda.Controllers
{
    public class ProductsController : ApiController
    {
        private Producto[] productos = new Producto[]
        {
            new Producto { Id = 1, Name = "Product 1" },
            new Producto { Id = 2, Name = "Product 2" },
            new Producto { Id = 3, Name = "Product 3" }
        };
        public ProductsController() { }

        public IEnumerable<Producto> GetAllProducts()
        {
            return productos;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = productos.FirstOrDefault(p => p.Id == id);
            if(productos.Any() ) {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
