using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Configuracion;
using System.Data.SqlClient;
using System.Data;

namespace DA.Configuracion
{
    public class DepartamentoDA
    {
        public ListDepartamentoET Get()
        {
            ListDepartamentoET departamentos = new ListDepartamentoET();
            using (SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Departamento_G", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        DepartamentoET depto = new DepartamentoET();
                        depto.DPId = Convert.ToInt32(rd["DPId"]);
                        depto.DPNombre = Convert.ToString(rd["DPNombre"]);
                        depto.DPCodigoPostal = Convert.ToString(rd["DPCodigoPostal"]);
                        depto.DPPaisId = Convert.ToInt32(rd["DPPaisId"]);
                        depto.DPCreado = Convert.ToDateTime(rd["DPCreado"]);
                        if (rd["DPModificado"] != DBNull.Value)
                            depto.DPModificado = Convert.ToDateTime(rd["DPModificado"]);
                        departamentos.Add(depto);
                    }
                }
            }
            return departamentos;
        }
        public DepartamentoET Insertar(DepartamentoET departamentos)
        {
            using (SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Departamento_I", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", departamentos.DPNombre);
                    cmd.Parameters.AddWithValue("@CodigoPostal", departamentos.DPCodigoPostal);
                    cmd.Parameters.AddWithValue("@PaisId", departamentos.DPPaisId);

                    con.Open();
                    departamentos.DPId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return departamentos;
        }

        public DepartamentoET DepartamentoById_G(int id)
        {
            DepartamentoET departamento = null;
            using(SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using(SqlCommand cmd = new SqlCommand("SP_DepartamentoById_G", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DPId", id);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        departamento = new DepartamentoET();
                        departamento.DPId = Convert.ToInt32(rd["DPId"]);
                        departamento.DPNombre = Convert.ToString(rd["DPNombre"]);
                        departamento.DPCodigoPostal = Convert.ToString(rd["DPCodigoPostal"]);
                        departamento.DPPaisId = Convert.ToInt32(rd["DPPaisId"]);
                        departamento.DPCreado = Convert.ToDateTime(rd["DPCreado"]);
                        if (rd["DPModificado"] != DBNull.Value)
                            departamento.DPModificado = Convert.ToDateTime(rd["DPModificado"]);


                    }
                }
            }
            return departamento;
        }

        public DepartamentoET Update(DepartamentoET depto)
        {
            using(SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using(SqlCommand cmd = new SqlCommand("SP_Departamento_U", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", depto.DPId);
                    cmd.Parameters.AddWithValue("@Nombre", depto.DPNombre);
                    cmd.Parameters.AddWithValue("@CodigoPostal", depto.DPCodigoPostal);
                    cmd.Parameters.AddWithValue("@PaisId", depto.DPPaisId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return depto;
        }
        public bool Delete(int id)
        {
            using(SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using(SqlCommand cmd = new SqlCommand("SP_Departamento_D", con))
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
