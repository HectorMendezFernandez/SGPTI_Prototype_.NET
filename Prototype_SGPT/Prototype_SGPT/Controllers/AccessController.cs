using Microsoft.AspNetCore.Mvc;
using Prototype_SGPT.Logic;
using Prototype_SGPT.Models;

//importamos librerias para hacer uso de las cookies y autorizaciones
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace Prototype_SGPT.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            //busca al usuario en la base de datos
            User usuario = new LogicDbApplication().EncontrarUsuario(email, password);
            if (usuario != null)
            {
                //creamos una cookie y todo su esquema de autorizacion para el usuario


                //pasamos el esquema del usuario (id, name, email, password, lastName, phoneNumber) 
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.name),
                    new Claim(ClaimTypes.Email, usuario.email),
                    new Claim("lastName", usuario.lastName)
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //se crea la cookie(esto es asincronico) y con esto confirmamos que esta autorizado
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));


                //CREAMOS LA SESION CON EL OBJETO USUARIO (para ingresar un objeto se debe de utilizar la libreria jsonConvert y pasar ese objeto a JSON)
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(usuario));

                //nos dirigimos a la pagina principal del controlador Home
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        public async Task<IActionResult> Logout()
        {
            //eliminamos la cookie creada anteriormente al cerrar la sesion (invocar este metodo de salir) (ya no estara autorizado)
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //cerramos la sesion (seteamos con valores por defecto)
            HttpContext.Session.SetString("SessionUser", "");


            //nos reedirigimos a l apagina de logeo nuevamente de access
            return RedirectToAction("Index", "Access");
        }
    }
}
