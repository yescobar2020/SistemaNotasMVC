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
    public class AlumnoDA
    {
        public ListAlumnoET Get()
        {
            ListAlumnoET alumnos = new ListAlumnoET();
            using(SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using(SqlCommand cmd= new SqlCommand("SP_Alumno_G", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        AlumnoET alu = new AlumnoET();
                        alu.ALId = Convert.ToInt32(rd["ALId"]);
                        alu.ALDocumento = Convert.ToString(rd["ALDocumento"]);
                        alu.ALNombre = Convert.ToString(rd["ALNombre"]);
                        alumnos.Add(alu);
                    }
                }
            }
            return alumnos;
        }
        public AlumnoET Insertar(AlumnoET alumnos)
        {
            using(SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using(SqlCommand cmd = new SqlCommand("SP_Alumno_I", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ALDocumento", alumnos.ALDocumento);
                    cmd.Parameters.AddWithValue("@ALNombre", alumnos.ALNombre);
                    con.Open();
                    alumnos.ALId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return alumnos;
        }
        public AlumnoET Update(AlumnoET alumno)
        {
            using(SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using(SqlCommand cmd = new SqlCommand("SP_Alumno_U", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ALId", alumno.ALId);
                    cmd.Parameters.AddWithValue("@ALDocumento", alumno.ALDocumento);
                    cmd.Parameters.AddWithValue("@ALNombre", alumno.ALNombre);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return alumno;
        }
        public AlumnoET AlumnoById_G(int id)
        {
            AlumnoET alumno = null;
            using(SqlConnection con= new SqlConnection(Conexion.CadenaConexion))
            {
                using(SqlCommand cmd = new SqlCommand("SP_AlumnoById_G", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ALId", id);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        alumno = new AlumnoET();
                        alumno.ALId = Convert.ToInt32(rd["ALId"]);
                        alumno.ALDocumento = Convert.ToString(rd["ALDocumento"]);
                        alumno.ALNombre = Convert.ToString(rd["ALNombre"]);
                    }
                }
            }
            return alumno;
        }
        public bool Delete(int id)
        {
            using(SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
            {
                using(SqlCommand cmd= new SqlCommand("SP_Alumno_D", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ALId", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}
