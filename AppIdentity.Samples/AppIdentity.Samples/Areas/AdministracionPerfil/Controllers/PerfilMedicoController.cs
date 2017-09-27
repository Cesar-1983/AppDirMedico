using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppIdentity.Samples.Areas.AdministracionPerfil.Models;
using Microsoft.AspNet.Identity;

namespace AppIdentity.Samples.Areas.AdministracionPerfil.Controllers
{
    public class PerfilMedicoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: AdministracionPerfil/PerfilMedico
        public ActionResult Index()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //var userid = User.Identity.GetUserId();
            //var perfilMedico = db.PerfilMedico.FirstOrDefault(p => p.Id == userid);

            //if (perfilMedico == null)
            //{
            //    return vi
            //    return HttpNotFound();
            //}

            //var perfil = new RegistroPerfilView {
            //    PrimerNombre = perfilMedico.PrimerNombre,
            //    SegundoNombre = perfilMedico.SegundoNombre,
            //    PrimerApellido = perfilMedico.PrimerApellido,
            //    SegundoApellido =perfilMedico.SegundoApellido,
            //    Photo = perfilMedico.Photo
            //};
            //return View(perfil);
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home",new { area="" });
            }
            ViewBag.Porcentaje = PorcentajeCompletacionPerfil();
            return View();
        }

        public bool HasPerfil()
        {
            var userId = User.Identity.GetUserId();
            var perfilMedico = db.PerfilMedico.FirstOrDefault(p => p.Id == userId);
            return perfilMedico != null ? true: false;
            

        }
        public bool HasEspecialidades()
        {
            var userId = User.Identity.GetUserId();
            var perfilMedico = db.PerfilMedico.FirstOrDefault(p => p.Id == userId);
            if (perfilMedico != null)
            {
                return perfilMedico.Especialidad != null;
            }
            return false;
        }
        public bool HasDirecciones()
        {
            var userId = User.Identity.GetUserId();
            var perfilMedico = db.PerfilMedico.FirstOrDefault(p => p.Id == userId);
            if (perfilMedico != null)
            {
                return perfilMedico.DireccionAtencion != null;
            }
            return false;
        }
        public bool HasContactos()
        {
            var userId = User.Identity.GetUserId();
            var perfilMedico = db.PerfilMedico.FirstOrDefault(p => p.Id == userId);
            if (perfilMedico != null)
            {
                return perfilMedico.Contactos != null;
            }
            return false;
        }
        public string PorcentajeCompletacionPerfil()
        {
            int porc = 0;
            

            if (HasPerfil())
                porc += 1; 
            if (HasEspecialidades())
                porc += 1;
            if (HasContactos())
                porc += 1;
            if (HasDirecciones())
                porc += 1;

            switch (porc)
            {
                case 1:
                    return "25%";
                    
                case 2:
                    return "50%";
                    
                case 3:
                    return "75%";
                    
                case 4:
                    return "100%";
                    
                default:
                    return "0%" ;
            }
        }
    }
}