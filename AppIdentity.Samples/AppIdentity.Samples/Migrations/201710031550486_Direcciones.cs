namespace AppIdentity.Samples.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Direcciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Municipio",
                c => new
                    {
                        MunicipioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Departamento_DepartamentoID = c.Int(),
                    })
                .PrimaryKey(t => t.MunicipioID)
                .ForeignKey("dbo.Departamento", t => t.Departamento_DepartamentoID)
                .Index(t => t.Departamento_DepartamentoID);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.DepartamentoID);
            
            AddColumn("dbo.DireccionAtencion", "MunicipioID", c => c.Int(nullable: false));
            CreateIndex("dbo.DireccionAtencion", "MunicipioID");
            AddForeignKey("dbo.DireccionAtencion", "MunicipioID", "dbo.Municipio", "MunicipioID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DireccionAtencion", "MunicipioID", "dbo.Municipio");
            DropForeignKey("dbo.Municipio", "Departamento_DepartamentoID", "dbo.Departamento");
            DropIndex("dbo.Municipio", new[] { "Departamento_DepartamentoID" });
            DropIndex("dbo.DireccionAtencion", new[] { "MunicipioID" });
            DropColumn("dbo.DireccionAtencion", "MunicipioID");
            DropTable("dbo.Departamento");
            DropTable("dbo.Municipio");
        }
    }
}
