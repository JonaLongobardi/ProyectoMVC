using System.ComponentModel.DataAnnotations;
namespace WebApplication3.Models
{
    public class Clientes
    {
        public int CLIENTES_COD { get; set; }

        [Required(ErrorMessage = "Ingrese nombre correcto")]
        public string NOMBRE { get; set; }

        [Required(ErrorMessage = "Ingrese apellido correcto")]
        public string APELLIDO { get; set; }

        [Required(ErrorMessage = "Ingrese el mail correcto")]
        public string CORREO { get; set; }

        [Required(ErrorMessage = "Ingrese tipo correcto")]
        public string TIPO_CLIENTE { get; set; }

        [Required(ErrorMessage = "Ingrese el cuit correcto")]
        public int CUIT_DNI { get; set; }

        [Required(ErrorMessage = "Ingrese la razon correcta")]
        public string RAZON_SOCIAL { get; set; }
        public int USUARIOS_CODIGO { get; set; }    
    }
}
