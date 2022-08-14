using Microsoft.AspNetCore.Mvc;
using Prototype_SGPT.Logic;
using Prototype_SGPT.Models;

namespace Prototype_SGPT.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string password)
        {
            //busca al usuario en la base de datos
            User usuario = new LogicDbApplication().EncontrarUsuario(name, password);
            if(usuario != null) return RedirectToAction("Index", "Home");

            return View();
        }
    }
}
