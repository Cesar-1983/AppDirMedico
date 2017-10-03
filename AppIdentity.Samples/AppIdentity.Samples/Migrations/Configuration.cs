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
                new Especialidad { Descripcion="Alergolog�a"},
                new Especialidad { Descripcion="Anestesiolog�a y reanimaci�n"},
                new Especialidad { Descripcion="Cardiolog�a"},
                new Especialidad { Descripcion="Gastroenterolog�a"},
                new Especialidad { Descripcion="Endocrinolog�a"},
                new Especialidad { Descripcion="Geriatr�a"},
                new Especialidad { Descripcion="Hematolog�a y hemoterapia"},
                new Especialidad { Descripcion="Infectolog�a"},
                new Especialidad { Descripcion="Medicina aeroespacial"},
                new Especialidad { Descripcion="Medicina del deporte"},
                new Especialidad { Descripcion="Medicina del trabajo"},
                new Especialidad { Descripcion="Medicina de urgencias"},
                new Especialidad { Descripcion="Medicina familiar y comunitaria"},
                new Especialidad { Descripcion="Medicina f�sica y rehabilitaci�n"},
                new Especialidad { Descripcion="Medicina intensiva"},
                new Especialidad { Descripcion="Medicina interna"},
                new Especialidad { Descripcion="Medicina legal y forense"},
                new Especialidad { Descripcion="Medicina preventiva y salud p�blica"},
                new Especialidad { Descripcion="Nefrolog�a"},
                new Especialidad { Descripcion="Neumolog�a"},
                new Especialidad { Descripcion="Neurolog�a"},
                new Especialidad { Descripcion="Nutriolog�a"},
                new Especialidad { Descripcion="Oftalmolog�a"},
                new Especialidad { Descripcion="Oncolog�a m�dica"},
                new Especialidad { Descripcion="Oncolog�a radioter�pica"},
                new Especialidad { Descripcion="Pediatr�a"},
                new Especialidad { Descripcion="Psiquiatr�a"},
                new Especialidad { Descripcion="Rehabilitaci�n"},
                new Especialidad { Descripcion="Reumatolog�a"},
                new Especialidad { Descripcion="Toxicolog�a"},
                new Especialidad { Descripcion="Urolog�a"},




            };

            var Especialidades2 = new List<Especialidad> {
                new Especialidad { Descripcion="Cirug�a cardiovascular"},
                new Especialidad { Descripcion="Cirug�a general y del aparato digestivo"},
                new Especialidad { Descripcion="Cirug�a oral y maxilofacial"},
                new Especialidad { Descripcion="Cirug�a ortop�dica y traumatolog�a"},
                new Especialidad { Descripcion="Cirug�a pedi�trica"},
                new Especialidad { Descripcion="Cirug�a pl�stica, est�tica y reparadora"},
                new Especialidad { Descripcion="Cirug�a tor�cica"},
                new Especialidad { Descripcion="Neurocirug�a"},
                new Especialidad { Descripcion="Proctolog�a"},




            };

            var Especialidades3 = new List<Especialidad> {
                new Especialidad { Descripcion="Angiolog�a y cirug�a vascular"},
                new Especialidad { Descripcion="Dermatolog�a m�dico-quir�rgica y venereolog�a"},
                new Especialidad { Descripcion="Estomatolog�a"},
                new Especialidad { Descripcion="Ginecolog�a y obstetricia o tocolog�a"},
                new Especialidad { Descripcion="Oftalmolog�a"},
                new Especialidad { Descripcion="Otorrinolaringolog�a"},
                new Especialidad { Descripcion="Urolog�a"},
                new Especialidad { Descripcion="Traumatolog�a"},




            };

            var TipoEspecialidades = new List<TipoEspecialidad> {
            new TipoEspecialidad { Descripcion="Cl�nicas",  Especialidad=Especialidades1 },
            new TipoEspecialidad { Descripcion="Quir�rgicas", Especialidad=Especialidades2 },
            new TipoEspecialidad { Descripcion="m�dico-quir�rgicas",Especialidad=Especialidades3}

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
            var List_Estel� = new List<Municipio>();
            var List_Granada = new List<Municipio>();
            var List_Jinotega = new List<Municipio>();
            var List_Le�n = new List<Municipio>();
            var List_Madriz = new List<Municipio>();
            var List_Managua = new List<Municipio>();
            var List_Masaya = new List<Municipio>();
            var List_Matagalpa = new List<Municipio>();
            var List_Nueva_Segovia = new List<Municipio>();
            var List_R�o_San_Juan = new List<Municipio>();
            var List_Rivas = new List<Municipio>();


            List_Caribe_Norte.Add(new Municipio { Nombre = "Bilwi" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Bonanza" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Mulukuk�" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Prinzapolka" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Rosita" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Siuna" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Waslala" });
            List_Caribe_Norte.Add(new Municipio { Nombre = "Wasp�n" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Bluefields" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Corn Island" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Desembocadura de R�o Grande" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "El Ayote" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "El Tortuguero" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Kukra Hill" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "La Cruz de R�o Grande" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Laguna de Perlas" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Muelle de los Bueyes" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Nueva Guinea" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "Paiwas" });
            List_Caribe_Sur.Add(new Municipio { Nombre = "El Rama" });
            List_Boaco.Add(new Municipio { Nombre = "Boaco" });
            List_Boaco.Add(new Municipio { Nombre = "Camoapa" });
            List_Boaco.Add(new Municipio { Nombre = "San Lorenzo" });
            List_Boaco.Add(new Municipio { Nombre = "San Jos� de Los Remates" });
            List_Boaco.Add(new Municipio { Nombre = "Santa Luc�a" });
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
            List_Chinandega.Add(new Municipio { Nombre = "Santo Tom�s del Norte" });
            List_Chinandega.Add(new Municipio { Nombre = "Somotillo" });
            List_Chinandega.Add(new Municipio { Nombre = "Puerto Moraz�n" });
            List_Chinandega.Add(new Municipio { Nombre = "Villanueva" });
            List_Chontales.Add(new Municipio { Nombre = "Acoyapa" });
            List_Chontales.Add(new Municipio { Nombre = "Comalapa" });
            List_Chontales.Add(new Municipio { Nombre = "San Francisco de Cuapa" });
            List_Chontales.Add(new Municipio { Nombre = "El Coral" });
            List_Chontales.Add(new Municipio { Nombre = "Juigalpa" });
            List_Chontales.Add(new Municipio { Nombre = "La Libertad" });
            List_Chontales.Add(new Municipio { Nombre = "San Pedro de L�vago" });
            List_Chontales.Add(new Municipio { Nombre = "Santo Domingo" });
            List_Chontales.Add(new Municipio { Nombre = "Santo Tom�s" });
            List_Chontales.Add(new Municipio { Nombre = "Villa Sandino" });
            List_Estel�.Add(new Municipio { Nombre = "Condega" });
            List_Estel�.Add(new Municipio { Nombre = "Estel�" });
            List_Estel�.Add(new Municipio { Nombre = "La Trinidad" });
            List_Estel�.Add(new Municipio { Nombre = "Pueblo Nuevo" });
            List_Estel�.Add(new Municipio { Nombre = "San Juan de Limay" });
            List_Estel�.Add(new Municipio { Nombre = "San Nicol�s" });
            List_Granada.Add(new Municipio { Nombre = "Diri�" });
            List_Granada.Add(new Municipio { Nombre = "Diriomo" });
            List_Granada.Add(new Municipio { Nombre = "Granada" });
            List_Granada.Add(new Municipio { Nombre = "Nandaime" });
            List_Jinotega.Add(new Municipio { Nombre = "El Cu�" });
            List_Jinotega.Add(new Municipio { Nombre = "Jinotega" });
            List_Jinotega.Add(new Municipio { Nombre = "La Concordia" });
            List_Jinotega.Add(new Municipio { Nombre = "San Jos� de Bocay" });
            List_Jinotega.Add(new Municipio { Nombre = "San Rafael del Norte" });
            List_Jinotega.Add(new Municipio { Nombre = "San Sebasti�n de Yal�" });
            List_Jinotega.Add(new Municipio { Nombre = "Santa Mar�a de Pantasma" });
            List_Jinotega.Add(new Municipio { Nombre = "Wiwil� de Jinotega" });
            List_Le�n.Add(new Municipio { Nombre = "Achuapa" });
            List_Le�n.Add(new Municipio { Nombre = "El Jicaral" });
            List_Le�n.Add(new Municipio { Nombre = "El Sauce" });
            List_Le�n.Add(new Municipio { Nombre = "La Paz Centro" });
            List_Le�n.Add(new Municipio { Nombre = "Larreynaga" });
            List_Le�n.Add(new Municipio { Nombre = "Le�n" });
            List_Le�n.Add(new Municipio { Nombre = "Nagarote" });
            List_Le�n.Add(new Municipio { Nombre = "Quezalguaque" });
            List_Le�n.Add(new Municipio { Nombre = "Santa Rosa del Pe��n" });
            List_Le�n.Add(new Municipio { Nombre = "Telica" });
            List_Madriz.Add(new Municipio { Nombre = "Las Sabanas" });
            List_Madriz.Add(new Municipio { Nombre = "Palacag�ina" });
            List_Madriz.Add(new Municipio { Nombre = "San Jos� de Cusmapa" });
            List_Madriz.Add(new Municipio { Nombre = "San Juan de R�o Coco" });
            List_Madriz.Add(new Municipio { Nombre = "San Lucas" });
            List_Madriz.Add(new Municipio { Nombre = "Somoto" });
            List_Madriz.Add(new Municipio { Nombre = "Telpaneca" });
            List_Madriz.Add(new Municipio { Nombre = "Totogalpa" });
            List_Madriz.Add(new Municipio { Nombre = "Yalag�ina" });
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
            List_Masaya.Add(new Municipio { Nombre = "La Concepci�n" });
            List_Masaya.Add(new Municipio { Nombre = "Masatepe" });
            List_Masaya.Add(new Municipio { Nombre = "Masaya" });
            List_Masaya.Add(new Municipio { Nombre = "Nandasmo" });
            List_Masaya.Add(new Municipio { Nombre = "Nindir�" });
            List_Masaya.Add(new Municipio { Nombre = "Niquinohomo" });
            List_Masaya.Add(new Municipio { Nombre = "San Juan de Oriente" });
            List_Masaya.Add(new Municipio { Nombre = "Tisma" });
            List_Matagalpa.Add(new Municipio { Nombre = "Ciudad Dar�o" });
            List_Matagalpa.Add(new Municipio { Nombre = "El Tuma - La Dalia" });
            List_Matagalpa.Add(new Municipio { Nombre = "Esquipulas" });
            List_Matagalpa.Add(new Municipio { Nombre = "Matagalpa" });
            List_Matagalpa.Add(new Municipio { Nombre = "Matigu�s" });
            List_Matagalpa.Add(new Municipio { Nombre = "Muy Muy" });
            List_Matagalpa.Add(new Municipio { Nombre = "Rancho Grande" });
            List_Matagalpa.Add(new Municipio { Nombre = "R�o Blanco" });
            List_Matagalpa.Add(new Municipio { Nombre = "San Dionisio" });
            List_Matagalpa.Add(new Municipio { Nombre = "San Isidro" });
            List_Matagalpa.Add(new Municipio { Nombre = "San Ram�n" });
            List_Matagalpa.Add(new Municipio { Nombre = "S�baco" });
            List_Matagalpa.Add(new Municipio { Nombre = "Terrabona" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Ciudad Antigua" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Dipilto" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "El J�caro" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "G�ig�il�" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Jalapa" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Macuelizo" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Mozonte" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Murra" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Ocotal" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Quilal�" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "San Fernando" });
            List_Nueva_Segovia.Add(new Municipio { Nombre = "Santa Mar�a" });
            List_R�o_San_Juan.Add(new Municipio { Nombre = "El Almendro" });
            List_R�o_San_Juan.Add(new Municipio { Nombre = "El Castillo" });
            List_R�o_San_Juan.Add(new Municipio { Nombre = "Morrito" });
            List_R�o_San_Juan.Add(new Municipio { Nombre = "San Carlos" });
            List_R�o_San_Juan.Add(new Municipio { Nombre = "San Juan del Norte" });
            List_R�o_San_Juan.Add(new Municipio { Nombre = "San Miguelito" });
            List_Rivas.Add(new Municipio { Nombre = "Altagracia" });
            List_Rivas.Add(new Municipio { Nombre = "Bel�n" });
            List_Rivas.Add(new Municipio { Nombre = "Buenos Aires" });
            List_Rivas.Add(new Municipio { Nombre = "C�rdenas" });
            List_Rivas.Add(new Municipio { Nombre = "Moyogalpa" });
            List_Rivas.Add(new Municipio { Nombre = "Potos�" });
            List_Rivas.Add(new Municipio { Nombre = "Rivas" });
            List_Rivas.Add(new Municipio { Nombre = "San Jorge" });
            List_Rivas.Add(new Municipio { Nombre = "San Juan del Sur" });
            List_Rivas.Add(new Municipio { Nombre = "Tola" });





            var Departamentos = new List<Departamento> {
                new Departamento { Nombre="Boaco", Municipio= List_Boaco},
                new Departamento { Nombre="Carazo", Municipio= List_Carazo},
                new Departamento { Nombre="Chinandega" ,Municipio= List_Chinandega},
                new Departamento { Nombre="Chontales", Municipio= List_Chontales},
                new Departamento { Nombre="Estel�", Municipio= List_Estel�},
                new Departamento { Nombre="Granada", Municipio= List_Granada},
                new Departamento { Nombre="Jinotega", Municipio= List_Jinotega},
                new Departamento { Nombre="Le�n", Municipio= List_Le�n},
                new Departamento { Nombre="Madriz", Municipio= List_Madriz},
                new Departamento { Nombre="Managua", Municipio= List_Managua},
                new Departamento { Nombre="Masaya", Municipio= List_Masaya},
                new Departamento { Nombre="Matagalpa", Municipio= List_Matagalpa},
                new Departamento { Nombre="Nueva Segovia", Municipio= List_Nueva_Segovia},
                new Departamento { Nombre="R�o San Juan", Municipio= List_R�o_San_Juan},
                new Departamento { Nombre="Rivas", Municipio= List_Rivas},
                new Departamento { Nombre="Atl�ntico Norte", Municipio= List_Caribe_Norte },
                new Departamento { Nombre="Atl�ntico Sur", Municipio= List_Caribe_Sur}
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
