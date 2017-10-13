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
using System.Threading.Tasks;

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

        
        public ActionResult Editar(string IdUsuario, int Id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var Contacto = db.Contactos.FirstOrDefault(c=> c.Id == IdUsuario && c.ContactosID==Id);
                RegistroContactosView v_Contacto = new RegistroContactosView();

                v_Contacto.Id = Contacto.Id;
                v_Contacto.ContactosID = Contacto.ContactosID;
                v_Contacto.Telefono = Contacto.Telefono;
                v_Contacto.Descripcion = Contacto.Descripcion;
                

                

                return View(v_Contacto);
            }
            return RedirectToAction("Login", "Account", new { area = "", returnUrl = Url.Action("Index", "PerfilMedico") });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,ContactosID,Telefono,Descripcion")] RegistroContactosView model)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var Contacto = db.Contactos.FirstOrDefault(c => c.Id == model.Id && c.ContactosID == model.ContactosID);
                    Contacto.Descripcion = model.Descripcion;
                    Contacto.Telefono = model.Telefono;

                    db.Entry(Contacto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "PerfilMedico");
                }
                return View(model);

                               
            }
            return RedirectToAction("Login", "Account", new { area = "", returnUrl = Url.Action("Index", "PerfilMedico") });
        }

        public async Task<ActionResult> Borrar(string IdUsuario, int Id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var Contacto = await db.Contactos.FindAsync(Id);
                RegistroContactosView v_Contacto = new RegistroContactosView();

                v_Contacto.Id = Contacto.Id;
                v_Contacto.ContactosID = Contacto.ContactosID;
                v_Contacto.Telefono = Contacto.Telefono;
                v_Contacto.Descripcion = Contacto.Descripcion;




                return PartialView("_Borrar", v_Contacto);
            }
            return RedirectToAction("Login", "Account", new { area = "", returnUrl = Url.Action("Index", "PerfilMedico") });
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BorrarConfirmado(int Id)
        {
            var Contacto = await db.Contactos.FindAsync(Id);
            db.Contactos.Remove(Contacto);
            await db.SaveChangesAsync();
            return Json(new { success = true });
        }

    }
}