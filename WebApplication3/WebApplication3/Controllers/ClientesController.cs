using Microsoft.AspNetCore.Mvc;
using WebApplication3.Datos;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ClientesController : Controller
    {   

        ClientesDatos ClientesDatos= new ClientesDatos();
        public IActionResult Listar()
        {
            var oLista = ClientesDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarNuevo(Clientes oCliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var rpta = ClientesDatos.Guardar(oCliente);

            if (rpta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
