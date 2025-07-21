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
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Category");
            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
