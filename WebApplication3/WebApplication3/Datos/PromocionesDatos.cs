using System.Data.SqlClient;
using System.Data;
using WebApplication3.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication3.Datos
{
    public class PromocionesDatos
    {
        public List<Promociones> Listar()
        {
            var oLista = new List<Promociones>();
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
                        oLista.Add(new Promociones()
                        {
                            PROMOCIONES_CODIGO = Convert.ToInt32(dr["PROMOCIONES_CODIGO"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            DESCUENTO = Convert.ToInt32(dr["DESCUENTO"]),
                        });
                    }
                }
            }
            return oLista;
        }

        public Promociones Obtener(int PROMOCIONES_CODIGO)
        {
            var oPromociones = new Promociones();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Obtener", connection);
                cmd.Parameters.AddWithValue("PROMOCIONES_CODIGO", PROMOCIONES_CODIGO);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oPromociones.PROMOCIONES_CODIGO = Convert.ToInt32(dr["PROMOCIONES_CODIGO"]);
                        oPromociones.NOMBRE = dr["NOMBRE"].ToString();
                        oPromociones.DESCUENTO = Convert.ToInt32(dr["DESCUENTO"]);
                    }
                }
            }
            return oPromociones;
        }

        public bool Guardar(Promociones oPromociones)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", connection);
                    cmd.Parameters.AddWithValue("NOMBRE", oPromociones.NOMBRE);
                    cmd.Parameters.AddWithValue("DESCUENTO", oPromociones.DESCUENTO);
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
        public bool Editar(Promociones oPromociones)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Editar", connection);
                    cmd.Parameters.AddWithValue("PROMOCIONES_CODIGO", oPromociones.PROMOCIONES_CODIGO);
                    cmd.Parameters.AddWithValue("NOMBRE", oPromociones.NOMBRE);
                    cmd.Parameters.AddWithValue("DESCUENTO", oPromociones.DESCUENTO);
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
        public bool Eliminar(int PROMOCIONES_CODIGO)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", connection);
                    cmd.Parameters.AddWithValue("PROMOCIONES_CODIGO", PROMOCIONES_CODIGO);
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
