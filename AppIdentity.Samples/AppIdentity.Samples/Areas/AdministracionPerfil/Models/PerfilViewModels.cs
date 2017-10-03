using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace AppIdentity.Samples.Areas.AdministracionPerfil.Models
{
    public class PerfilViewModels
    {
    }
    public class RegistroPerfilView
    {

        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [StringLength(200)]
        [Display(Name = "Descripción Corta")]
        public string DescripcionCorta { get; set; }

        [StringLength(500)]
        [Display(Name = "Descripción Larga")]
        public string DescripcionLarga { get; set; }

        [Display(Name = "Foto de Perfil")]
        public byte[] Photo { get; set; }

        public List<DireccionAtencionView> Direcciones { get; set; }
    }

    public class DireccionAtencionView {

        public int DireccionAtencionID { get; set; }

        [Display(Name ="Direccion")]
        public string Direccion { get; set; }

    }
}