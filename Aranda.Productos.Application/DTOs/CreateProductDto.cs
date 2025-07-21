using System.ComponentModel.DataAnnotations;

namespace Aranda.Productos.Application.DTOs
{
    public class CreateProductDto
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int CategoriaId { get; set; }

        public string Imagen { get; set; }
    }
} 