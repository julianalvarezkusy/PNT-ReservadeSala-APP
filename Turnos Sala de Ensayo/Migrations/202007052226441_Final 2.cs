namespace Turnos_Sala_de_Ensayo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServicioAdicionals", "ReservaDeSala_Id", "dbo.ReservaDeSalas");
            DropIndex("dbo.ServicioAdicionals", new[] { "ReservaDeSala_Id" });
            DropColumn("dbo.ServicioAdicionals", "ReservaDeSala_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServicioAdicionals", "ReservaDeSala_Id", c => c.Int());
            CreateIndex("dbo.ServicioAdicionals", "ReservaDeSala_Id");
            AddForeignKey("dbo.ServicioAdicionals", "ReservaDeSala_Id", "dbo.ReservaDeSalas", "Id");
        }
    }
}
