

using System;
using System.Data;
using System.Data.SqlClient;
using ET.Acceso;

namespace DA.Acceso
{
    public class LoginDA
    {
        public LoginET Ingreso(string user, string pass)
        {

            LoginET login = null;
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
                        login = new LoginET();
                        login.LGId = Convert.ToInt32(rd["LGId"]);
                        login.LGUsuario = Convert.ToString(rd["LGUsuario"]);
                        login.LGContraseña = Convert.ToString(rd["LGContraseña"]);                       
                    }                                        
                }
            }
            return login;
        } 
    }
}
