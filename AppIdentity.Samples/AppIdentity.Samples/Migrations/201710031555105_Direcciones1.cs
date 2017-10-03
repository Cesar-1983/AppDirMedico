namespace AppIdentity.Samples.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Direcciones1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Municipio", "Departamento_DepartamentoID", "dbo.Departamento");
            DropIndex("dbo.Municipio", new[] { "Departamento_DepartamentoID" });
            RenameColumn(table: "dbo.Municipio", name: "Departamento_DepartamentoID", newName: "DepartamentoID");
            AlterColumn("dbo.Municipio", "DepartamentoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Municipio", "DepartamentoID");
            AddForeignKey("dbo.Municipio", "DepartamentoID", "dbo.Departamento", "DepartamentoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Municipio", "DepartamentoID", "dbo.Departamento");
            DropIndex("dbo.Municipio", new[] { "DepartamentoID" });
            AlterColumn("dbo.Municipio", "DepartamentoID", c => c.Int());
            RenameColumn(table: "dbo.Municipio", name: "DepartamentoID", newName: "Departamento_DepartamentoID");
            CreateIndex("dbo.Municipio", "Departamento_DepartamentoID");
            AddForeignKey("dbo.Municipio", "Departamento_DepartamentoID", "dbo.Departamento", "DepartamentoID");
        }
    }
}
