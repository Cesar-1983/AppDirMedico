namespace AppIdentity.Samples.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DireccionAtencion",
                c => new
                    {
                        DireccionAtencionID = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DireccionAtencionID)
                .ForeignKey("dbo.PerfilMedico", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DireccionAtencion", "Id", "dbo.PerfilMedico");
            DropIndex("dbo.DireccionAtencion", new[] { "Id" });
            DropTable("dbo.DireccionAtencion");
        }
    }
}
