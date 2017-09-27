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

            TipoEspecialidades.ForEach(e => context.TipoEspecialidad.AddOrUpdate(p => p.Descripcion, e));
            context.SaveChanges();
        }

    }
}
