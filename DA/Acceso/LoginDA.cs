

using System;
using System.Data;
using System.Data.SqlClient;
using ET.Acceso;

namespace DA.Acceso
{
    public class LoginDA
    {
        public LoginResult Ingreso(string user, string pass)
        {

            LoginResult login = null;
            using(SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Ingresar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LGUsuario", user);
                    cmd.Parameters.AddWithValue("@LGContraseña", pass);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        login = new LoginResult();
                        login.Login.LGId = Convert.ToInt32(rd["LGId"]);
                        login.Login.LGUsuario = Convert.ToString(rd["LGUsuario"]);
                        login.Login.LGContraseña = Convert.ToString(rd["LGContraseña"]);                       
                        login.Profesor.PFId = Convert.ToInt32(rd["PFId"]);                       
                        login.Profesor.PFNombre = Convert.ToString(rd["PFNombre"]);                       
                        login.Profesor.PFDocumento = Convert.ToString(rd["PFDocumento"]);
                    }                                        
                }
            }
            return login;
        } 
    }
}
