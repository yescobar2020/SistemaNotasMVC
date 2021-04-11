

using System;
using System.Data;
using System.Data.SqlClient;
using ET.Configuracion;

namespace DA.Configuracion
{
    public class MateriasDA
    {
        public MateriasET Insertar(MateriasET materias)
        {
            using (SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Materias_I", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MTNombre", materias.MTNombre);                    
                    con.Open();
                    materias.MTId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return materias;
        }
        
        public ListMateriasET Get()
        {
            ListMateriasET materias = new ListMateriasET();
            using (SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Materias_G", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        MateriasET materia = new MateriasET();
                        materia.MTId = Convert.ToInt32(rd["MTId"]);
                        materia.MTNombre = Convert.ToString(rd["MTNombre"]);
                        materias.Add(materia);
                    }
                }
            }
            return materias;
        }

    }

}
