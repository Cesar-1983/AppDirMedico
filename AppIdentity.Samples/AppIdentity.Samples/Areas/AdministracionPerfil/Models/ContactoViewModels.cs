using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace AppIdentity.Samples.Areas.AdministracionPerfil.Models
{
    public class ContactoViewModels
    {
    }

    public class RegistroContactosView
    {
        [HiddenInput(DisplayValue = false)]
        public int ContactosID { get; set; }
        [StringLength(15)]
        [Display(Name ="Número de Telefono")]
        [Required(ErrorMessage ="El número de telefono es requerido")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{8}",ErrorMessage = "Numero de telefono Invalido")]
        public string Telefono { get; set; }
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
    }
}