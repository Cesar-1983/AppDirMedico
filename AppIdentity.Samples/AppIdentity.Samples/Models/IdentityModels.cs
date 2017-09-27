﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<TipoEspecialidad> TipoEspecialidad { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<PerfilMedico> PerfilMedico { get; set; }
        public DbSet<Contactos> Contactos { get; set; }
    }

    public class TipoEspecialidad {
        public int TipoEspecialidadID { get; set; }
        public string Descripcion { get; set; }

    }

    public class Especialidad {
        public int EspecialidadID { get; set; }
        public string Descripcion { get; set; }

        public virtual TipoEspecialidad TipoEspecialidad { get; set; }

        public virtual ICollection<PerfilMedico> PerfilMedico { get; set; }
    }

    public class PerfilMedico {
        public int PerfilMedicoID { get; set; }

        [StringLength(100)]
        public string PrimerNombre { get; set; }

        [StringLength(100)]
        public string SegundoNombre { get; set; }

        [StringLength(100)]
        public string PrimerApellido { get; set; }

        [StringLength(100)]
        public string SegundoApellido { get; set; }

        [StringLength(200)]
        public string DescripcionCorta { get; set; }
        [StringLength(500)]
        public string DescripcionLarga { get; set; }

        public byte[] Photo { get; set; }
        public virtual ICollection<Especialidad> Especialidad { get; set; }


        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }

    public class Contactos {
        public int ContactosID { get; set; }
        [StringLength(15)]
        public string Telefono { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }

        public virtual PerfilMedico PerfilMedico { get; set; }
    }
}