namespace Aranda.Productos.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public string BlobImagen { get; set; }
        public virtual Category Categoria { get; set; }
    }
}