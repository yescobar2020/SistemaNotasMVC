

namespace ET.Acceso
{
    public class LoginResult
    {
        public LoginResult()
        {
            Login = new LoginET();
            Profesor = new ProfesorET();
        }
        public LoginET Login { get; set; }
        public ProfesorET Profesor { get; set; }
    }
}
