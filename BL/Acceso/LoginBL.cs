

using DA.Acceso;
using ET.Acceso;

namespace BL.Acceso
{
     public class LoginBL
    {
        LoginDA loginDA = new LoginDA();
        public LoginET Ingresar(string user, string pass)
        {
            return loginDA.Ingreso(user, pass);
        }
    }
}
