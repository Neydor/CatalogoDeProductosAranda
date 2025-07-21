using Aranda.Productos.Domain.Entities;
using Aranda.Productos.Infrastructure.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aranda.Productos.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext() : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Product>().ToTable("Products", "dbo");
            modelBuilder.Entity<Category>().ToTable("Categories", "dbo");

            base.OnModelCreating(modelBuilder);
        }
    }
}
