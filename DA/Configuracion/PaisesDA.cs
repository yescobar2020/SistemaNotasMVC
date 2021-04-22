using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Configuracion;

namespace DA.Configuracion
{
   public class PaisesDA
    {
        public PaisesET Insertar(PaisesET paises)
        {
            using(SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using(SqlCommand cmd = new SqlCommand("SP_Paises_I", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAName", paises.PAName);
                    cmd.Parameters.AddWithValue("@PALanguage", paises.PALanguage);

                    con.Open();
                    paises.PAId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return paises;
        }

        public ListPaisesET Get()
        {
            ListPaisesET paises = new ListPaisesET();
            using (SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Paises_G", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        PaisesET pais = new PaisesET();
                        pais.PAId = Convert.ToInt32(rd["PAId"]);
                        pais.PAName = Convert.ToString(rd["PAName"]);
                        pais.PALanguage = Convert.ToString(rd["PALanguage"]);
                        pais.PACreate = Convert.ToDateTime(rd["PACreate"]);
                        if (rd["PAModified"] != DBNull.Value)   
                            pais.PAModified = Convert.ToDateTime(rd["PAModified"]);
                        paises.Add(pais);
                    }
                }
            }
            return paises;
        }
        public PaisesET Update(PaisesET paises)
        {
            using (SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Paises_U", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAId", paises.PAId);
                    cmd.Parameters.AddWithValue("@PAName", paises.PAName);
                    cmd.Parameters.AddWithValue("@PALanguage", paises.PALanguage);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return paises;

        }
        public PaisesET PaisesById_G(int id)
        {
            PaisesET pais = null;
            using (SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_PaisesById_G", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAId",id );
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        pais = new PaisesET();
                        pais.PAId = Convert.ToInt32(rd["PAId"]);
                        pais.PAName = Convert.ToString(rd["PAName"]);
                        pais.PALanguage = Convert.ToString(rd["PALanguage"]);
                        pais.PACreate = Convert.ToDateTime(rd["PACreate"]);
                        if (rd["PAModified"] != DBNull.Value)
                            pais.PAModified = Convert.ToDateTime(rd["PAModified"]);
                        
                    }
                }
            }
            return pais;
        }
        public bool Delete( int id)
        {
            using (SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Paises_D", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                   
                }
            }
            return true;

        }
    }
}
