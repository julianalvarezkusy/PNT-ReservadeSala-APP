namespace Turnos_Sala_de_Ensayo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salas", "Precio", c => c.Double(nullable: false));
            AddColumn("dbo.Salas", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salas", "Descripcion");
            DropColumn("dbo.Salas", "Precio");
        }
    }
}
