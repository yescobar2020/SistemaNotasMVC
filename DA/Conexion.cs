

using System.Configuration;

namespace DA
{
     public static class Conexion
    {
        public static string CadenaConexion
        {
            get { return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString; }
        } 
    }
}
