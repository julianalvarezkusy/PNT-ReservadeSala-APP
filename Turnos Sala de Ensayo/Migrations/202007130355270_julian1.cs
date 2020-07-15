namespace Turnos_Sala_de_Ensayo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class julian1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServicioAdicionals", "Cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.ServicioAdicionals", "ReservaDeSala_Id", c => c.Int());
            CreateIndex("dbo.ServicioAdicionals", "ReservaDeSala_Id");
            AddForeignKey("dbo.ServicioAdicionals", "ReservaDeSala_Id", "dbo.ReservaDeSalas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicioAdicionals", "ReservaDeSala_Id", "dbo.ReservaDeSalas");
            DropIndex("dbo.ServicioAdicionals", new[] { "ReservaDeSala_Id" });
            DropColumn("dbo.ServicioAdicionals", "ReservaDeSala_Id");
            DropColumn("dbo.ServicioAdicionals", "Cantidad");
        }
    }
}
