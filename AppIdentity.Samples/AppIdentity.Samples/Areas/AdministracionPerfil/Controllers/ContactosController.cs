using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppIdentity.Samples.Areas.AdministracionPerfil.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using Microsoft.AspNet.Identity.Owin;

namespace AppIdentity.Samples.Areas.AdministracionPerfil.Controllers
{
    public class ContactosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: AdministracionPerfil/Contactos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            return RedirectToAction("Login", "Account", new { area = "" , returnUrl = Url.Action("Registro", "Contactos") });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(RegistroContactosView modelcontacto)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var perfil = db.PerfilMedico.Find(User.Identity.GetUserId());
                    if (perfil != null)
                    {
                        Contactos contacto = new Contactos();
                        contacto.Id = perfil.Id;
                        contacto.Descripcion = modelcontacto.Descripcion;
                        contacto.Telefono = modelcontacto.Telefono;

                        db.Contactos.Add(contacto);
                        db.SaveChanges();
                        
                    }
                    return RedirectToAction("Index", "PerfilMedico");
                   
                }
                return View(modelcontacto);
            }
            return RedirectToAction("Login", "Account", new { area = "" ,returnUrl = Url.Action("Registro", "Contactos") });
        }

    }
}