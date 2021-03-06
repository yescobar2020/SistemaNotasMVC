

using System.Web;
using System.Web.Mvc;
using ET.Acceso;
using SistemaNotasMVC.Controllers;

namespace SistemaNotasMVC.Filters
{
    public class VerificaSesion: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            try
            {
                base.OnActionExecuting(filterContext);
                var usuario = (LoginResult)HttpContext.Current.Session["User"];
                if (usuario==null)
                {
                    if(filterContext.Controller is AccesoController == false)   
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                }
            }
            catch (System.Exception)
            {

                filterContext.HttpContext.Response.Redirect("/Acceso/Login");

            }

        }
    }
}