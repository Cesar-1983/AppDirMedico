namespace AppIdentity.Samples.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IdentitySample.Models;
    using System.Collections.Generic;


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

            TipoEspecialidades.ForEach(e => context.TipoEspecialidad.AddOrUpdate(p => p.Descripcion, e));
            context.SaveChanges();
        }

    }
}
