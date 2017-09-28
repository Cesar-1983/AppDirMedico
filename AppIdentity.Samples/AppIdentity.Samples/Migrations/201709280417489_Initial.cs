namespace AppIdentity.Samples.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contactos",
                c => new
                    {
                        ContactosID = c.Int(nullable: false, identity: true),
                        Telefono = c.String(maxLength: 15),
                        Descripcion = c.String(maxLength: 50),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContactosID)
                .ForeignKey("dbo.PerfilMedico", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PerfilMedico",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PrimerNombre = c.String(maxLength: 100),
                        SegundoNombre = c.String(maxLength: 100),
                        PrimerApellido = c.String(maxLength: 100),
                        SegundoApellido = c.String(maxLength: 100),
                        DescripcionCorta = c.String(maxLength: 200),
                        DescripcionLarga = c.String(maxLength: 500),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Especialidad",
                c => new
                    {
                        EspecialidadID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        TipoEspecialidadID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EspecialidadID)
                .ForeignKey("dbo.TipoEspecialidad", t => t.TipoEspecialidadID, cascadeDelete: true)
                .Index(t => t.TipoEspecialidadID);
            
            CreateTable(
                "dbo.TipoEspecialidad",
                c => new
                    {
                        TipoEspecialidadID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoEspecialidadID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.EspecialidadPerfilMedico",
                c => new
                    {
                        Especialidad_EspecialidadID = c.Int(nullable: false),
                        PerfilMedico_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Especialidad_EspecialidadID, t.PerfilMedico_Id })
                .ForeignKey("dbo.Especialidad", t => t.Especialidad_EspecialidadID, cascadeDelete: true)
                .ForeignKey("dbo.PerfilMedico", t => t.PerfilMedico_Id, cascadeDelete: true)
                .Index(t => t.Especialidad_EspecialidadID)
                .Index(t => t.PerfilMedico_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PerfilMedico", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Especialidad", "TipoEspecialidadID", "dbo.TipoEspecialidad");
            DropForeignKey("dbo.EspecialidadPerfilMedico", "PerfilMedico_Id", "dbo.PerfilMedico");
            DropForeignKey("dbo.EspecialidadPerfilMedico", "Especialidad_EspecialidadID", "dbo.Especialidad");
            DropForeignKey("dbo.DireccionAtencion", "Id", "dbo.PerfilMedico");
            DropForeignKey("dbo.Contactos", "Id", "dbo.PerfilMedico");
            DropIndex("dbo.EspecialidadPerfilMedico", new[] { "PerfilMedico_Id" });
            DropIndex("dbo.EspecialidadPerfilMedico", new[] { "Especialidad_EspecialidadID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Especialidad", new[] { "TipoEspecialidadID" });
            DropIndex("dbo.DireccionAtencion", new[] { "Id" });
            DropIndex("dbo.PerfilMedico", new[] { "Id" });
            DropIndex("dbo.Contactos", new[] { "Id" });
            DropTable("dbo.EspecialidadPerfilMedico");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TipoEspecialidad");
            DropTable("dbo.Especialidad");
            DropTable("dbo.DireccionAtencion");
            DropTable("dbo.PerfilMedico");
            DropTable("dbo.Contactos");
        }
    }
}
