using Aranda.Productos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aranda.Productos.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Product");
            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasColumnName("Id") 
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 

            Property(p => p.Nombre)
                .IsRequired()       
                .HasMaxLength(100); 

            Property(p => p.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            Property(p => p.CategoriaId).IsRequired();

            HasRequired(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId)
                .WillCascadeOnDelete(false);

            Property(p => p.BlobImagen)
                .IsOptional()
                .HasMaxLength(4096);
        }
    }
}
