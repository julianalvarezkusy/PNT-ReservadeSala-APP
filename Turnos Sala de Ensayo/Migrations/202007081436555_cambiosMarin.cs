namespace Turnos_Sala_de_Ensayo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosMarin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservaDeSalas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSala = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        IdTurno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Double(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServicioAdicionals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Double(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turnoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        EsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Turnoes");
            DropTable("dbo.ServicioAdicionals");
            DropTable("dbo.Salas");
            DropTable("dbo.ReservaDeSalas");
        }
    }
}
