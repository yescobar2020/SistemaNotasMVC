using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Acceso;
using System.Data.SqlClient;
using System.Data;

namespace DA.Configuracion
{
    public class ProfesorDA
    {
        public ListProfesorET Get()
        {
            ListProfesorET profesores = new ListProfesorET();
            using(SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using(SqlCommand cmd= new SqlCommand("SP_Profesor_G", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        ProfesorET prof = new ProfesorET();
                        prof.PFId = Convert.ToInt32(rd["PFId"]);
                        prof.PFNombre = Convert.ToString(rd["PFNombre"]);
                        prof.PFDocumento = Convert.ToString(rd["PFDocumento"]);
                        profesores.Add(prof);
                    }
                }
            }
            return profesores;
        }
    }
}
