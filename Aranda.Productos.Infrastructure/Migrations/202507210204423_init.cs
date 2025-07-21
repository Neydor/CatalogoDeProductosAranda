namespace Aranda.Productos.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        CategoriaId = c.Int(nullable: false),
                        BlobImagen = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoriaId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoriaId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
