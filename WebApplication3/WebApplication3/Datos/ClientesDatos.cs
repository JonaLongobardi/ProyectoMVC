using WebApplication3.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication3.Datos
{
    public class ClientesDatos
    {
        public List<Clientes> Listar()
        {
            var oLista = new List<Clientes>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("Listar", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Clientes()
                        {
                            CLIENTES_COD = Convert.ToInt32(dr["CLIENTES_COD"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            APELLIDO = dr["APELLIDO"].ToString(),
                            CORREO = dr["CORREO"].ToString(),
                            TIPO_CLIENTE = dr["TIPO_CLIENTE"].ToString(),
                            CUIT_DNI = Convert.ToInt32(dr["CUIT_DNI"]),
                            RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString(),
                        });
                    }
                }
            }
            return oLista; 
        }

        public Clientes Obtener(int CLIENTES_COD)
        {   
            var oClientes = new Clientes();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Obtener", connection);
                cmd.Parameters.AddWithValue("CLIENTES_COD", CLIENTES_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oClientes.CLIENTES_COD = Convert.ToInt32(dr["CLIENTES_COD"]);
                        oClientes.NOMBRE = dr["NOMBRE"].ToString();
                        oClientes.APELLIDO= dr["APELLIDO"].ToString();
                        oClientes.CORREO= dr["CORREO"].ToString();
                        oClientes.TIPO_CLIENTE = dr["TIPO_CLIENTE"].ToString();
                        oClientes.CUIT_DNI = Convert.ToInt32(dr["CUIT_DNI"]);
                        oClientes.RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString();
                    }
                }
            }
            return oClientes;
        }

        public bool Guardar(Clientes oCliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", connection);
                    cmd.Parameters.AddWithValue("NOMBRE", oCliente.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oCliente.APELLIDO);
                    cmd.Parameters.AddWithValue("CORREO", oCliente.CORREO);
                    cmd.Parameters.AddWithValue("TIPO_CLIENTE", oCliente.TIPO_CLIENTE);
                    cmd.Parameters.AddWithValue("CUIT_DNI", oCliente.CUIT_DNI);
                    cmd.Parameters.AddWithValue("RAZON_SOCIAL", oCliente.RAZON_SOCIAL);
                }
                rpta = true;
            }
            catch(Exception e) 
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Editar(Clientes oCliente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Editar", connection);
                    cmd.Parameters.AddWithValue("CLIENTES_COD", oCliente.CLIENTES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", oCliente.NOMBRE);
                    cmd.Parameters.AddWithValue("APELLIDO", oCliente.APELLIDO);
                    cmd.Parameters.AddWithValue("CORREO", oCliente.CORREO);
                    cmd.Parameters.AddWithValue("TIPO_CLIENTE", oCliente.TIPO_CLIENTE);
                    cmd.Parameters.AddWithValue("CUIT_DNI", oCliente.CUIT_DNI);
                    cmd.Parameters.AddWithValue("RAZON_SOCIAL", oCliente.RAZON_SOCIAL);
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
        public bool Eliminar(int CLIENTES_COD)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", connection);
                    cmd.Parameters.AddWithValue("CLIENTES_COD", CLIENTES_COD);
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
