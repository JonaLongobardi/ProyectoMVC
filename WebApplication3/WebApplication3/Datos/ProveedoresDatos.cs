using System.Data.SqlClient;
using System.Data;
using WebApplication3.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication3.Datos
{
    public class ProveedoresDatos
    {
        public List<Proveedores> Listar()
        {
            var oLista = new List<Proveedores>();
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
                        oLista.Add(new Proveedores()
                        {
                            PROVEEDORES_COD = Convert.ToInt32(dr["PROVEEDORES_COD"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDO = dr["APELLIDO"].ToString(),
                            CUIT = Convert.ToInt32(dr["CUIT"]),
                        });
                    }
                }
            }
            return oLista;
        }

        public Proveedores Obtener(int PROVEEDORES_COD)
        {
            var oProveedores = new Proveedores();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Obtener", connection);
                cmd.Parameters.AddWithValue("PROVEEDORES_COD", PROVEEDORES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oProveedores.PROVEEDORES_COD = Convert.ToInt32(dr["PROVEEDORES_COD"]);
                        oProveedores.NOMBRE = dr["NOMBRE"].ToString();
                        oProveedores.APELLIDO = dr["APELLIDO"].ToString();
                        oProveedores.CUIT = Convert.ToInt32(dr["CUIT"]);
                    }
                }
            }
            return oProveedores;
        }

        public bool Guardar(Proveedores oProveedores)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", connection);
                    cmd.Parameters.AddWithValue("NOMBRE", oProveedores.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oProveedores.APELLIDO);
                    cmd.Parameters.AddWithValue("CUIT", oProveedores.CUIT);
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
        public bool Editar(Proveedores oProveedores)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Editar", connection);
                    cmd.Parameters.AddWithValue("PROVEEDORES_COD", oProveedores.PROVEEDORES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", oProveedores.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oProveedores.APELLIDO);
                    cmd.Parameters.AddWithValue("CUIT", oProveedores.CUIT);
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
        public bool Eliminar(int PROVEEDORES_COD)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", connection);
                    cmd.Parameters.AddWithValue("PROVEEDORES_COD", PROVEEDORES_COD);
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
