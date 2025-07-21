using System.Collections.Generic;

namespace Aranda.Productos.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}