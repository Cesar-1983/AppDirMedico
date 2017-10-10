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

            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    //return RedirectToAction("Index", "Home",new { area="" });
                    return RedirectToAction("Login", "Account", new { area = "", returnUrl = Url.Action("Index", "PerfilMedico") });
                }
                var perfil = db.PerfilMedico.Find(User.Identity.GetUserId());

                List<DireccionAtencionView> direcciones = new List<DireccionAtencionView>();

                RegistroPerfilView perfilview = new RegistroPerfilView();
                perfilview.Id = perfil.Id;
                perfilview.PrimerNombre = perfil.PrimerNombre;
                perfilview.SegundoNombre = perfil.SegundoNombre;
                perfilview.PrimerApellido = perfil.PrimerApellido;
                perfilview.SegundoApellido = perfil.SegundoApellido;
                perfilview.DescripcionCorta = perfil.DescripcionCorta;
                perfilview.DescripcionLarga = perfil.DescripcionLarga;
                perfilview.Photo = perfil.Photo;



                foreach (var item in perfil.DireccionAtencion)
                {
                    perfilview.Direcciones.Add(new DireccionAtencionView { DireccionAtencionID = item.DireccionAtencionID, Direccion = item.Direccion });
                }
                if (perfil.Contactos != null)
                {
                    perfilview.Contactos = new List<ContactosView>();
                    foreach (var item in perfil.Contactos)
                    {
                        var Contacto = new ContactosView { ContactosID = item.ContactosID, Id = item.Id, Descripcion = item.Descripcion, Telefono = item.Telefono };
                        perfilview.Contactos.Add(Contacto);
                    }
                }

                ViewBag.Porcentaje = PorcentajeCompletacionPerfil();
                return View(perfilview);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return View("Error");
            }
        }

        public ActionResult Registro()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            return RedirectToAction("Login", "Account", new { area = "", returnUrl = Url.Action("Index", "PerfilMedico") });
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
                return RedirectToAction("Login", "Account", new { area = "", returnUrl = Url.Action("Index", "PerfilMedico") });
            }
        }


        public ActionResult Editar(string UserId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var perfil = db.PerfilMedico.Find(UserId);
                RegistroPerfilView v_perfilmedico = new RegistroPerfilView();
                v_perfilmedico.Id = perfil.Id;

                v_perfilmedico.PrimerNombre = perfil.PrimerNombre;
                v_perfilmedico.SegundoNombre = perfil.SegundoNombre;
                v_perfilmedico.PrimerApellido = perfil.PrimerApellido;
                v_perfilmedico.SegundoApellido = perfil.SegundoApellido;
                v_perfilmedico.DescripcionCorta = perfil.DescripcionCorta;
                v_perfilmedico.DescripcionLarga = perfil.DescripcionLarga;

                return View(v_perfilmedico);
            }
            return RedirectToAction("Login", "Account", new { area = "", returnUrl = Url.Action("Index", "PerfilMedico") });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Exclude = "perfilPhoto")] RegistroPerfilView modelperfil)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {

                    var perfil = db.PerfilMedico.Find(modelperfil.Id);

                    if (perfil != null)
                    {
                        byte[] imageData = null;
                        HttpPostedFileBase file = Request.Files["perfilphoto"];
                        //PerfilMedico v_perfilmedico = new PerfilMedico();

                        perfil.PrimerNombre = modelperfil.PrimerNombre;
                        perfil.SegundoNombre = modelperfil.SegundoNombre;
                        perfil.PrimerApellido = modelperfil.PrimerApellido;
                        perfil.SegundoApellido = modelperfil.SegundoApellido;
                        perfil.DescripcionCorta = modelperfil.DescripcionCorta;
                        perfil.DescripcionLarga = modelperfil.DescripcionLarga;

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

                        perfil.Photo = imageData;

                        db.Entry(perfil).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(modelperfil);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "", returnUrl = Url.Action("Index", "PerfilMedico") });
            }
        }

        #region Metodos
        public bool HasPerfil()
        {
            var userId = User.Identity.GetUserId();
            var perfilMedico = db.PerfilMedico.FirstOrDefault(p => p.Id == userId);
            return perfilMedico != null ? true : false;


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
                    return "0";
            }
        }
        #endregion

    }
}