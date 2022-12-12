using System.Data.SqlClient;
using System.Data;
using WebApplication3.Models;

namespace WebApplication3.Datos
{
    public class OrdenesDatos
    {
        public List<Ordenes> Listar()
        {
            var oLista = new List<Ordenes>();
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
                        oLista.Add(new Ordenes()
                        {
                            ORDENES_COD = Convert.ToInt32(dr["ORDENES_COD"]),
                            FECHA_ENTREGA = dr["FECHA_ENTREGA"].ToString(),
                            FECHA_GENERACION = dr["FECHA_GENERACION"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public Ordenes Obtener(int ORDENES_COD)
        {
            var oOrdenes = new Ordenes();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Obtener", connection);
                cmd.Parameters.AddWithValue("ORDENES_COD", ORDENES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oOrdenes.ORDENES_COD = Convert.ToInt32(dr["ORDENES_COD"]);
                        oOrdenes.FECHA_ENTREGA = dr["FECHA_ENTREGA"].ToString();
                        oOrdenes.FECHA_GENERACION = dr["FECHA_GENERACION"].ToString();
                    }
                }
            }
            return oOrdenes;
        }

        public bool Guardar(Ordenes oOrdenes)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", connection);
                    cmd.Parameters.AddWithValue("FECHA_ENTREGA", oOrdenes.FECHA_ENTREGA);
                    cmd.Parameters.AddWithValue("FECHA_GENERACION", oOrdenes.FECHA_GENERACION);
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
        public bool Editar(Ordenes oOrdenes)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Editar", connection);
                    cmd.Parameters.AddWithValue("ORDENES_COD", oOrdenes.ORDENES_COD);
                    cmd.Parameters.AddWithValue("FECHA_ENTREGA", oOrdenes.FECHA_ENTREGA);
                    cmd.Parameters.AddWithValue("FECHA_GENERACION", oOrdenes.FECHA_GENERACION);
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
        public bool Eliminar(int ORDENES_COD)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", connection);
                    cmd.Parameters.AddWithValue("ORDENES_COD", ORDENES_COD);
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
