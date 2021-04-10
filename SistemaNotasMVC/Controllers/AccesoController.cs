
using System;
using System.Web.Mvc;
using BL.Acceso;
using ET.Acceso;

namespace SistemaNotasMVC.Controllers
{       
    public class AccesoController : Controller
    {
        LoginBL loginBL = new LoginBL();
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            try
            {
                LoginET login = loginBL.Ingresar(user, pass);
                if(login == null)
                {
                    ViewBag.Error = " Usuario o contraseña invalido";
                    return View();
                }
                Session["User"] = login;
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }            
        }
            
    }
}