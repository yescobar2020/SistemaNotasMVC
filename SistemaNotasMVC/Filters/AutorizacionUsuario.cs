using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaNotasMVC.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AutorizacionUsuario: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            var usuario = HttpContext.Current.Session["User"];
            if (usuario == null)
            {
                filterContext.HttpContext.Response.Redirect("/Acceso/Login");
            }
        }
    }
}