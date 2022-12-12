using System.Data.SqlClient;
namespace WebApplication3.Datos
{
    public class Conexion
    {   

        private string cadenaSQL = string.Empty;    
        public Conexion() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build();
            cadenaSQL = builder.GetSection("ConnectionString:CadenaSQL").Value;
        }
        public string getCadenaSQL() { return cadenaSQL; }

    }
    
}
