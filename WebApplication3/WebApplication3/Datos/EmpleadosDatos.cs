using System.Data.SqlClient;
using System.Data;
using WebApplication3.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication3.Datos
{
    public class EmpleadosDatos
    {
        public List<Empleados> Listar()
        {
            var oLista = new List<Empleados>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("Listar", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Empleados()
                        {
                            EMPLEADOS_CODIGO = Convert.ToInt32(dr["EMPLEADOS_COD"]),
                            Supervisor_CODIGO = Convert.ToInt32(dr["Supervisor_CODIGO"]),
                            TIPO_EMPLEADO = dr["TIPO_EMPLEADO"].ToString(),
                            APELLIDO_SUPERVISOR = dr["APELLIDO_SUPERVISOR"].ToString(),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDO = dr["APELLIDO"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public Empleados Obtener(int EMPLEADOS_CODIGO)
        {
            var oEmpleados = new Empleados();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Obtener", connection);
                cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", EMPLEADOS_CODIGO);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oEmpleados.EMPLEADOS_CODIGO = Convert.ToInt32(dr["EMPLEADOS_COD"]);
                        oEmpleados.Supervisor_CODIGO = Convert.ToInt32(dr["Supervisor_CODIGO"]);
                        oEmpleados.TIPO_EMPLEADO = dr["TIPO_EMPLEADO"].ToString();
                        oEmpleados.APELLIDO_SUPERVISOR = dr["APELLIDO_SUPERVISOR"].ToString();
                        oEmpleados.NOMBRE = dr["NOMBRE"].ToString();
                        oEmpleados.APELLIDO = dr["APELLIDO"].ToString();
                    }
                }
            }
            return oEmpleados;
        }

        public bool Guardar(Empleados oEmpleados)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", connection);
                    cmd.Parameters.AddWithValue("Supervisor_CODIGO", oEmpleados.Supervisor_CODIGO);
                    cmd.Parameters.AddWithValue("TIPO_EMPLEADO", oEmpleados.TIPO_EMPLEADO);
                    cmd.Parameters.AddWithValue("APELLIDO_SUPERVISOR", oEmpleados.APELLIDO_SUPERVISOR);
                    cmd.Parameters.AddWithValue("NOMBRE", oEmpleados.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oEmpleados.APELLIDO);
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Editar(Empleados oEmpleados)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Editar", connection);
                    cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", oEmpleados.EMPLEADOS_CODIGO);
                    cmd.Parameters.AddWithValue("Supervisor_CODIGO", oEmpleados.Supervisor_CODIGO);
                    cmd.Parameters.AddWithValue("TIPO_EMPLEADO", oEmpleados.TIPO_EMPLEADO);
                    cmd.Parameters.AddWithValue("APELLIDO_SUPERVISOR", oEmpleados.APELLIDO_SUPERVISOR);
                    cmd.Parameters.AddWithValue("NOMBRE", oEmpleados.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oEmpleados.APELLIDO);
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Eliminar (int EMPLEADOS_CODIGO)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", connection);
                    cmd.Parameters.AddWithValue("EMPLEADOS_CODIGO", EMPLEADOS_CODIGO);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();  
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
