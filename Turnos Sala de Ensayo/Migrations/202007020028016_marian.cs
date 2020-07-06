namespace Turnos_Sala_de_Ensayo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class marian : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "EsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "EsAdmin");
        }
    }
}
