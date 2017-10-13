using System.Web.Mvc;

namespace AppIdentity.Samples.Areas.AdministracionPerfil
{
    public class AdministracionPerfilAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdministracionPerfil";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "AdministracionPerfil_Perfil",
                url: "AdministracionPerfil/{controller}/{action}/{IdUsuario}/{Id}",
                defaults: new { controller = "Contactos", action = "Index", IdUsuario = UrlParameter.Optional, Id = UrlParameter.Optional }
            );
            context.MapRoute(
                "AdministracionPerfil_default",
                "AdministracionPerfil/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}