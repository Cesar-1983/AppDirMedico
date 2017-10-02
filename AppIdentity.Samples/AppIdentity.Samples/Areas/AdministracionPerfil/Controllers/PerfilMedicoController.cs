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
    public class PerfilMedicoController : Controller
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
            var perfil = db.PerfilMedico.Find(User.Identity.GetUserId());

            RegistroPerfilView perfilview = new RegistroPerfilView();
            perfilview.PrimerNombre = perfil.PrimerNombre;
            perfilview.SegundoNombre = perfil.SegundoNombre;
            perfilview.PrimerApellido = perfil.PrimerApellido;
            perfilview.SegundoApellido = perfil.SegundoApellido;
            perfilview.DescripcionCorta = perfil.DescripcionCorta;
            perfilview.DescripcionLarga = perfil.DescripcionLarga;
            perfilview.Photo = perfil.Photo;


            ViewBag.Porcentaje = PorcentajeCompletacionPerfil();
            return View(perfilview);
        }

        public ActionResult Registro()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registro([Bind(Exclude = "perfilphoto")] RegistroPerfilView perfil)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {

                    byte[] imageData = null;
                    //ApplicationUserManager userManager;
                    var user = User.Identity;
                    var usuario = UserManager.FindById(User.Identity.GetUserId());



                    PerfilMedico v_perfilmedico = new PerfilMedico();
                    v_perfilmedico.Id = user.GetUserId();

                    v_perfilmedico.PrimerNombre = perfil.PrimerNombre;
                    v_perfilmedico.SegundoNombre = perfil.SegundoNombre;
                    v_perfilmedico.PrimerApellido = perfil.PrimerApellido;
                    v_perfilmedico.SegundoApellido = perfil.SegundoApellido;
                    v_perfilmedico.DescripcionCorta = perfil.DescripcionCorta;
                    v_perfilmedico.DescripcionLarga = perfil.DescripcionLarga;

                    HttpPostedFileBase file = Request.Files["perfilphoto"];

                    if (file.ContentLength > 0)
                    {
                        //HttpPostedFileBase file = Request.Files["perfilphoto"];
                        imageData = new byte[file.ContentLength];
                        file.InputStream.Read(imageData, 0, imageData.Length);

                    }
                    else
                    {
                        string fileName = HttpContext.Server.MapPath(@"~/Images/no-image.png");
                        FileInfo fileInfo = new FileInfo(fileName);
                        long imageFileLength = fileInfo.Length;
                        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        imageData = br.ReadBytes((int)imageFileLength);

                    }

                    v_perfilmedico.Photo = imageData;

                    usuario.PerfilMedico = v_perfilmedico;


                    try
                    {
                        UserManager.Update(usuario);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }
                    return RedirectToAction("Index");
                }
                return View(perfil);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
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
                return perfilMedico.Especialidad.Count > 0;
            }
            return false;
        }
        public bool HasDirecciones()
        {
            var userId = User.Identity.GetUserId();
            var perfilMedico = db.PerfilMedico.FirstOrDefault(p => p.Id == userId);
            if (perfilMedico != null)
            {
                return perfilMedico.DireccionAtencion.Count > 0;
            }
            return false;
        }
        public bool HasContactos()
        {
            var userId = User.Identity.GetUserId();
            var perfilMedico = db.PerfilMedico.FirstOrDefault(p => p.Id == userId);
            if (perfilMedico != null)
            {
                return perfilMedico.Contactos.Count > 0;
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
                    return "25";
                    
                case 2:
                    return "50";
                    
                case 3:
                    return "75";
                    
                case 4:
                    return "100";
                    
                default:
                    return "0" ;
            }
        }
    }
}