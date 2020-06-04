namespace PrestamoLibros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "prest.AlquileresDeLibro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoAlquiler = c.String(nullable: false, maxLength: 3),
                        FechaAlquiler = c.DateTime(nullable: false),
                        FechaRealDevolucion = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        CopiaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prest.Clientes", t => t.ClienteId)
                .ForeignKey("prest.CopiasDeLibro", t => t.CopiaId)
                .Index(t => t.ClienteId)
                .Index(t => t.CopiaId);
            
            CreateTable(
                "prest.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoDeCliente = c.String(nullable: false, maxLength: 3),
                        NombresDelCliente = c.String(nullable: false, maxLength: 50),
                        ApellidosDelCliente = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "prest.CopiasDeLibro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroCopia = c.Int(nullable: false),
                        LibroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prest.Libros", t => t.LibroId)
                .Index(t => t.LibroId);
            
            CreateTable(
                "prest.Libros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoDeLibro = c.String(nullable: false, maxLength: 3),
                        TituloDeLibro = c.String(nullable: false, maxLength: 50),
                        ISBN = c.String(nullable: false, maxLength: 13),
                        Autor = c.String(nullable: false, maxLength: 100),
                        MateriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("prest.Materias", t => t.MateriaId)
                .Index(t => t.MateriaId);
            
            CreateTable(
                "prest.Materias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoDeMateria = c.String(nullable: false, maxLength: 3),
                        DescripcionDeMateria = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("prest.AlquileresDeLibro", "CopiaId", "prest.CopiasDeLibro");
            DropForeignKey("prest.Libros", "MateriaId", "prest.Materias");
            DropForeignKey("prest.CopiasDeLibro", "LibroId", "prest.Libros");
            DropForeignKey("prest.AlquileresDeLibro", "ClienteId", "prest.Clientes");
            DropIndex("prest.Libros", new[] { "MateriaId" });
            DropIndex("prest.CopiasDeLibro", new[] { "LibroId" });
            DropIndex("prest.AlquileresDeLibro", new[] { "CopiaId" });
            DropIndex("prest.AlquileresDeLibro", new[] { "ClienteId" });
            DropTable("prest.Materias");
            DropTable("prest.Libros");
            DropTable("prest.CopiasDeLibro");
            DropTable("prest.Clientes");
            DropTable("prest.AlquileresDeLibro");
        }
    }
}
