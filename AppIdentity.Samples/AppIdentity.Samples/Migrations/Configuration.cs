namespace AppIdentity.Samples.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IdentitySample.Models;
    using System.Collections.Generic;
    using System.Web;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentitySample.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentitySample.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //InitializeIdentityForEF(context);
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }
            if (!context.Users.Any(u => u.UserName == "crivera@midominio.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "crivera@midominio.com", Email = "crivera@midominio.com" };
                var result = manager.Create(user, "123456!");
                manager.SetLockoutEnabled(user.Id, false);
                manager.AddToRole(user.Id, "Admin");
            }
            var Especialidades1 = new List<Especialidad> {
                new Especialidad { Descripcion="Alergología"},
                new Especialidad { Descripcion="Anestesiología y reanimación"},
                new Especialidad { Descripcion="Cardiología"},
                new Especialidad { Descripcion="Gastroenterología"},
                new Especialidad { Descripcion="Endocrinología"},
                new Especialidad { Descripcion="Geriatría"},
                new Especialidad { Descripcion="Hematología y hemoterapia"},
                new Especialidad { Descripcion="Infectología"},
                new Especialidad { Descripcion="Medicina aeroespacial"},
                new Especialidad { Descripcion="Medicina del deporte"},
                new Especialidad { Descripcion="Medicina del trabajo"},
                new Especialidad { Descripcion="Medicina de urgencias"},
                new Especialidad { Descripcion="Medicina familiar y comunitaria"},
                new Especialidad { Descripcion="Medicina física y rehabilitación"},
                new Especialidad { Descripcion="Medicina intensiva"},
                new Especialidad { Descripcion="Medicina interna"},
                new Especialidad { Descripcion="Medicina legal y forense"},
                new Especialidad { Descripcion="Medicina preventiva y salud pública"},
                new Especialidad { Descripcion="Nefrología"},
                new Especialidad { Descripcion="Neumología"},
                new Especialidad { Descripcion="Neurología"},
                new Especialidad { Descripcion="Nutriología"},
                new Especialidad { Descripcion="Oftalmología"},
                new Especialidad { Descripcion="Oncología médica"},
                new Especialidad { Descripcion="Oncología radioterápica"},
                new Especialidad { Descripcion="Pediatría"},
                new Especialidad { Descripcion="Psiquiatría"},
                new Especialidad { Descripcion="Rehabilitación"},
                new Especialidad { Descripcion="Reumatología"},
                new Especialidad { Descripcion="Toxicología"},
                new Especialidad { Descripcion="Urología"},




            };

            var Especialidades2 = new List<Especialidad> {
                new Especialidad { Descripcion="Cirugía cardiovascular"},
                new Especialidad { Descripcion="Cirugía general y del aparato digestivo"},
                new Especialidad { Descripcion="Cirugía oral y maxilofacial"},
                new Especialidad { Descripcion="Cirugía ortopédica y traumatología"},
                new Especialidad { Descripcion="Cirugía pediátrica"},
                new Especialidad { Descripcion="Cirugía plástica, estética y reparadora"},
                new Especialidad { Descripcion="Cirugía torácica"},
                new Especialidad { Descripcion="Neurocirugía"},
                new Especialidad { Descripcion="Proctología"},




            };

            var Especialidades3 = new List<Especialidad> {
                new Especialidad { Descripcion="Angiología y cirugía vascular"},
                new Especialidad { Descripcion="Dermatología médico-quirúrgica y venereología"},
                new Especialidad { Descripcion="Estomatología"},
                new Especialidad { Descripcion="Ginecología y obstetricia o tocología"},
                new Especialidad { Descripcion="Oftalmología"},
                new Especialidad { Descripcion="Otorrinolaringología"},
                new Especialidad { Descripcion="Urología"},
                new Especialidad { Descripcion="Traumatología"},




            };

            var TipoEspecialidades = new List<TipoEspecialidad> {
            new TipoEspecialidad { Descripcion="Clínicas",  Especialidad=Especialidades1 },
            new TipoEspecialidad { Descripcion="Quirúrgicas", Especialidad=Especialidades2 },
            new TipoEspecialidad { Descripcion="médico-quirúrgicas",Especialidad=Especialidades3}

            };

            //var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            //const string name = "admin@example.com";
            //const string password = "Admin@123456";
            //const string roleName = "Admin";
            //var user = userManager.FindByName(name);
            //if (user == null)
            //{
            //    user = new ApplicationUser { UserName = name, Email = name };
            //    var result = userManager.Create(user, password);
            //    result = userManager.SetLockoutEnabled(user.Id, false);
            //}

            TipoEspecialidades.ForEach(e => context.TipoEspecialidad.AddOrUpdate(p => p.Descripcion, e));
            context.SaveChanges();
        }
        //public static void InitializeIdentityForEF(ApplicationDbContext db)
        //{
        //    var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
        //    const string name = "admin@example.com";
        //    const string password = "Admin@123456";
        //    const string roleName = "Admin";

        //    //Create Role Admin if it does not exist
        //    var role = roleManager.FindByName(roleName);
        //    if (role == null)
        //    {
        //        role = new IdentityRole(roleName);
        //        var roleresult = roleManager.Create(role);
        //    }

        //    var user = userManager.FindByName(name);
        //    if (user == null)
        //    {
        //        user = new ApplicationUser { UserName = name, Email = name };
        //        var result = userManager.Create(user, password);
        //        result = userManager.SetLockoutEnabled(user.Id, false);
        //    }

        //    // Add user admin to Role Admin if not already added
        //    var rolesForUser = userManager.GetRoles(user.Id);
        //    if (!rolesForUser.Contains(role.Name))
        //    {
        //        var result = userManager.AddToRole(user.Id, role.Name);
        //    }
        //}
    }
}
