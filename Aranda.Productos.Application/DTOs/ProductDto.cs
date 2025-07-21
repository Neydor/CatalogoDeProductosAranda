using System;

namespace Aranda.Productos.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
    }
} 