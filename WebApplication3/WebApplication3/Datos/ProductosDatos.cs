using System.Data.SqlClient;
using System.Data;
using WebApplication3.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication3.Datos
{
    public class ProductosDatos
    {
        public List<Productos> Listar()
        {
            var oLista = new List<Productos>();
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
                        oLista.Add(new Productos()
                        {
                            PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            PRECIO = Convert.ToInt32(dr["PRECIO"]),
                            STOCK = Convert.ToInt32(dr["STOCK"]),
                        });
                    }
                }
            }
            return oLista;
        }

        public Productos Obtener(int PRODUCTOS_COD)
        {
            var oProductos = new Productos();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Obtener", connection);
                cmd.Parameters.AddWithValue("PRODUCTOS_COD", PRODUCTOS_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oProductos.PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]);
                        oProductos.NOMBRE = dr["NOMBRE"].ToString();
                        oProductos.PRECIO = Convert.ToInt32(dr["PRECIO"]);
                        oProductos.STOCK = Convert.ToInt32(dr["STOCK"]);
                    }
                }
            }
            return oProductos;
        }

        public bool Guardar(Productos oProductos)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", connection);
                    cmd.Parameters.AddWithValue("NOMBRE", oProductos.NOMBRE);
                    cmd.Parameters.AddWithValue("PRECIO", oProductos.PRECIO);
                    cmd.Parameters.AddWithValue("STOCK", oProductos.STOCK);
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
        public bool Editar(Productos oProductos)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Editar", connection);
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", oProductos.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", oProductos.NOMBRE);
                    cmd.Parameters.AddWithValue("PRECIO", oProductos.PRECIO);
                    cmd.Parameters.AddWithValue("STOCK", oProductos.STOCK);
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
        public bool Eliminar(int PRODUCTOS_COD)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", connection);
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", PRODUCTOS_COD);
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
