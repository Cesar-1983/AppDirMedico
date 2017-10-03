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

            //Se agregan los departamentos y municipios
            var List_Caribe_Norte = new List<Municipio>();
            var List_Caribe_Sur = new List<Municipio>();
            var List_Boaco = new List<Municipio>();
            var List_Carazo = new List<Municipio>();
            var List_Chinandega = new List<Municipio>();
            var List_Chontales = new List<Municipio>();
            var List_Estelí = new List<Municipio>();
            var List_Granada = new List<Municipio>();
            var List_Jinotega = new List<Municipio>();
            var List_León = new List<Municipio>();
            var List_Madriz = new List<Municipio>();
            var List_Managua = new List<Municipio>();
            var List_Masaya = new List<Municipio>();
            var List_Matagalpa = new List<Municipio>();
            var List_Nueva_Segovia = new List<Municipio>();
            var List_Río_San_Juan = new List<Municipio>();
            var List_Rivas = new List<Municipio>();


            List_Caribe_Norte.Add(new Municipio { Nombre = "Bilwi" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Bonanza" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Mulukukú" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Prinzapolka" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Rosita" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Siuna" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Waslala" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Waspán" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Bluefields" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Corn Island" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Desembocadura de Río Grande" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "El Ayote" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "El Tortuguero" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Kukra Hill" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "La Cruz de Río Grande" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Laguna de Perlas" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Muelle de los Bueyes" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Nueva Guinea" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Paiwas" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "El Rama" });
            List_Boaco.Add(new Municipio { Nombre = "Boaco" });
            List_Boaco.Add(new Municipio { Nombre = "Camoapa" });
            List_Boaco.Add(new Municipio { Nombre = "San Lorenzo" });
            List_Boaco.Add(new Municipio { Nombre = "San José de Los Remates" });
            List_Boaco.Add(new Municipio { Nombre = "Santa Lucía" });
            List_Boaco.Add(new Municipio { Nombre = "Teustepe" });
            List_Carazo.Add(new Municipio { Nombre = "Diriamba" });
            List_Carazo.Add(new Municipio { Nombre = "Dolores" });
            List_Carazo.Add(new Municipio { Nombre = "El Rosario" });
            List_Carazo.Add(new Municipio { Nombre = "Jinotepe" });
            List_Carazo.Add(new Municipio { Nombre = "La Conquista" });
            List_Carazo.Add(new Municipio { Nombre = "La Paz de Oriente" });
            List_Carazo.Add(new Municipio { Nombre = "San Marcos" });
            List_Carazo.Add(new Municipio { Nombre = "Santa Teresa" });
            List_Chinandega.Add(new Municipio { Nombre = "Chichigalpa" });
            List_Chinandega.Add(new Municipio { Nombre = "Chinandega" });
            List_Chinandega.Add(new Municipio { Nombre = "Cinco Pinos" });
            List_Chinandega.Add(new Municipio { Nombre = "Corinto" });
            List_Chinandega.Add(new Municipio { Nombre = "El Realejo" });
            List_Chinandega.Add(new Municipio { Nombre = "El Viejo" });
            List_Chinandega.Add(new Municipio { Nombre = "Posoltega" });
            List_Chinandega.Add(new Municipio { Nombre = "San Francisco del Norte" });
            List_Chinandega.Add(new Municipio { Nombre = "San Pedro del Norte" });
            List_Chinandega.Add(new Municipio { Nombre = "Santo Tomás del Norte" });
            List_Chinandega.Add(new Municipio { Nombre = "Somotillo" });
            List_Chinandega.Add(new Municipio { Nombre = "Puerto Morazán" });
            List_Chinandega.Add(new Municipio { Nombre = "Villanueva" });
            List_Chontales.Add(new Municipio { Nombre = "Acoyapa" });
            List_Chontales.Add(new Municipio { Nombre = "Comalapa" });
            List_Chontales.Add(new Municipio { Nombre = "San Francisco de Cuapa" });
            List_Chontales.Add(new Municipio { Nombre = "El Coral" });
            List_Chontales.Add(new Municipio { Nombre = "Juigalpa" });
            List_Chontales.Add(new Municipio { Nombre = "La Libertad" });
            List_Chontales.Add(new Municipio { Nombre = "San Pedro de Lóvago" });
            List_Chontales.Add(new Municipio { Nombre = "Santo Domingo" });
            List_Chontales.Add(new Municipio { Nombre = "Santo Tomás" });
            List_Chontales.Add(new Municipio { Nombre = "Villa Sandino" });
            List_Estelí.Add(new Municipio { Nombre = "Condega" });
            List_Estelí.Add(new Municipio { Nombre = "Estelí" });
            List_Estelí.Add(new Municipio { Nombre = "La Trinidad" });
            List_Estelí.Add(new Municipio { Nombre = "Pueblo Nuevo" });
            List_Estelí.Add(new Municipio { Nombre = "San Juan de Limay" });
            List_Estelí.Add(new Municipio { Nombre = "San Nicolás" });
            List_Granada.Add(new Municipio { Nombre = "Diriá" });
            List_Granada.Add(new Municipio { Nombre = "Diriomo" });
            List_Granada.Add(new Municipio { Nombre = "Granada" });
            List_Granada.Add(new Municipio { Nombre = "Nandaime" });
            List_Jinotega.Add(new Municipio { Nombre = "El Cuá" });
            List_Jinotega.Add(new Municipio { Nombre = "Jinotega" });
            List_Jinotega.Add(new Municipio { Nombre = "La Concordia" });
            List_Jinotega.Add(new Municipio { Nombre = "San José de Bocay" });
            List_Jinotega.Add(new Municipio { Nombre = "San Rafael del Norte" });
            List_Jinotega.Add(new Municipio { Nombre = "San Sebastián de Yalí" });
            List_Jinotega.Add(new Municipio { Nombre = "Santa María de Pantasma" });
            List_Jinotega.Add(new Municipio { Nombre = "Wiwilí de Jinotega" });
            List_León.Add(new Municipio { Nombre = "Achuapa" });
            List_León.Add(new Municipio { Nombre = "El Jicaral" });
            List_León.Add(new Municipio { Nombre = "El Sauce" });
            List_León.Add(new Municipio { Nombre = "La Paz Centro" });
            List_León.Add(new Municipio { Nombre = "Larreynaga" });
            List_León.Add(new Municipio { Nombre = "León" });
            List_León.Add(new Municipio { Nombre = "Nagarote" });
            List_León.Add(new Municipio { Nombre = "Quezalguaque" });
            List_León.Add(new Municipio { Nombre = "Santa Rosa del Peñón" });
            List_León.Add(new Municipio { Nombre = "Telica" });
            List_Madriz.Add(new Municipio { Nombre = "Las Sabanas" });
            List_Madriz.Add(new Municipio { Nombre = "Palacagüina" });
            List_Madriz.Add(new Municipio { Nombre = "San José de Cusmapa" });
            List_Madriz.Add(new Municipio { Nombre = "San Juan de Río Coco" });
            List_Madriz.Add(new Municipio { Nombre = "San Lucas" });
            List_Madriz.Add(new Municipio { Nombre = "Somoto" });
            List_Madriz.Add(new Municipio { Nombre = "Telpaneca" });
            List_Madriz.Add(new Municipio { Nombre = "Totogalpa" });
            List_Madriz.Add(new Municipio { Nombre = "Yalagüina" });
            List_Managua.Add(new Municipio { Nombre = "Ciudad Sandino" });
            List_Managua.Add(new Municipio { Nombre = "El Crucero" });
            List_Managua.Add(new Municipio { Nombre = "Managua" });
            List_Managua.Add(new Municipio { Nombre = "Mateare" });
            List_Managua.Add(new Municipio { Nombre = "San Francisco Libre" });
            List_Managua.Add(new Municipio { Nombre = "San Rafael del Sur" });
            List_Managua.Add(new Municipio { Nombre = "Ticuantepe" });
            List_Managua.Add(new Municipio { Nombre = "Tipitapa" });
            List_Managua.Add(new Municipio { Nombre = "Villa El Carmen" });
            List_Masaya.Add(new Municipio { Nombre = "Catarina" });
            List_Masaya.Add(new Municipio { Nombre = "La Concepción" });
            List_Masaya.Add(new Municipio { Nombre = "Masatepe" });
            List_Masaya.Add(new Municipio { Nombre = "Masaya" });
            List_Masaya.Add(new Municipio { Nombre = "Nandasmo" });
            List_Masaya.Add(new Municipio { Nombre = "Nindirí" });
            List_Masaya.Add(new Municipio { Nombre = "Niquinohomo" });
            List_Masaya.Add(new Municipio { Nombre = "San Juan de Oriente" });
            List_Masaya.Add(new Municipio { Nombre = "Tisma" });
            List_Matagalpa.Add(new Municipio { Nombre = "Ciudad Darío" });
            List_Matagalpa.Add(new Municipio { Nombre = "El Tuma - La Dalia" });
            List_Matagalpa.Add(new Municipio { Nombre = "Esquipulas" });
            List_Matagalpa.Add(new Municipio { Nombre = "Matagalpa" });
            List_Matagalpa.Add(new Municipio { Nombre = "Matiguás" });
            List_Matagalpa.Add(new Municipio { Nombre = "Muy Muy" });
            List_Matagalpa.Add(new Municipio { Nombre = "Rancho Grande" });
            List_Matagalpa.Add(new Municipio { Nombre = "Río Blanco" });
            List_Matagalpa.Add(new Municipio { Nombre = "San Dionisio" });
            List_Matagalpa.Add(new Municipio { Nombre = "San Isidro" });
            List_Matagalpa.Add(new Municipio { Nombre = "San Ramón" });
            List_Matagalpa.Add(new Municipio { Nombre = "Sébaco" });
            List_Matagalpa.Add(new Municipio { Nombre = "Terrabona" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Ciudad Antigua" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Dipilto" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "El Jícaro" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Güigüilí" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Jalapa" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Macuelizo" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Mozonte" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Murra" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Ocotal" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Quilalí" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "San Fernando" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Santa María" });
            List_Río_San_Juan.Add(new Municipio { Nombre = "El Almendro" });
            List_Río_San_Juan.Add(new Municipio { Nombre = "El Castillo" });
            List_Río_San_Juan.Add(new Municipio { Nombre = "Morrito" });
            List_Río_San_Juan.Add(new Municipio { Nombre = "San Carlos" });
            List_Río_San_Juan.Add(new Municipio { Nombre = "San Juan del Norte" });
            List_Río_San_Juan.Add(new Municipio { Nombre = "San Miguelito" });
            List_Rivas.Add(new Municipio { Nombre = "Altagracia" });
            List_Rivas.Add(new Municipio { Nombre = "Belén" });
            List_Rivas.Add(new Municipio { Nombre = "Buenos Aires" });
            List_Rivas.Add(new Municipio { Nombre = "Cárdenas" });
            List_Rivas.Add(new Municipio { Nombre = "Moyogalpa" });
            List_Rivas.Add(new Municipio { Nombre = "Potosí" });
            List_Rivas.Add(new Municipio { Nombre = "Rivas" });
            List_Rivas.Add(new Municipio { Nombre = "San Jorge" });
            List_Rivas.Add(new Municipio { Nombre = "San Juan del Sur" });
            List_Rivas.Add(new Municipio { Nombre = "Tola" });





            var Departamentos = new List<Departamento> {
                new Departamento { Nombre="Boaco", Municipio= List_Boaco},
                new Departamento { Nombre="Carazo", Municipio= List_Carazo},
                new Departamento { Nombre="Chinandega" ,Municipio= List_Chinandega},
                new Departamento { Nombre="Chontales", Municipio= List_Chontales},
                new Departamento { Nombre="Estelí", Municipio= List_Estelí},
                new Departamento { Nombre="Granada", Municipio= List_Granada},
                new Departamento { Nombre="Jinotega", Municipio= List_Jinotega},
                new Departamento { Nombre="León", Municipio= List_León},
                new Departamento { Nombre="Madriz", Municipio= List_Madriz},
                new Departamento { Nombre="Managua", Municipio= List_Managua},
                new Departamento { Nombre="Masaya", Municipio= List_Masaya},
                new Departamento { Nombre="Matagalpa", Municipio= List_Matagalpa},
                new Departamento { Nombre="Nueva Segovia", Municipio= List_Nueva_Segovia},
                new Departamento { Nombre="Río San Juan", Municipio= List_Río_San_Juan},
                new Departamento { Nombre="Rivas", Municipio= List_Rivas},
                new Departamento { Nombre="Atlántico Norte", Municipio= List_Caribe_Norte },
                new Departamento { Nombre="Atlántico Sur", Municipio= List_Caribe_Sur}
            };


            Departamentos.ForEach(e => context.Departamento.AddOrUpdate(p => p.Nombre, e));

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
