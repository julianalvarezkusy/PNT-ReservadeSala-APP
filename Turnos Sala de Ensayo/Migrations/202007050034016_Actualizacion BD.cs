namespace Turnos_Sala_de_Ensayo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServicioAdicionals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Double(nullable: false),
                        Descripcion = c.String(),
                        ReservaDeSala_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReservaDeSalas", t => t.ReservaDeSala_Id)
                .Index(t => t.ReservaDeSala_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicioAdicionals", "ReservaDeSala_Id", "dbo.ReservaDeSalas");
            DropIndex("dbo.ServicioAdicionals", new[] { "ReservaDeSala_Id" });
            DropTable("dbo.ServicioAdicionals");
        }
    }
}
