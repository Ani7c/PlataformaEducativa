using Ecosistemas_Marinos.Entidades;
using LogicaAplicacion.InterfaceUseCase;
using LogicaAplicacion.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace WebApp.Controllers
{
    public class AutorizacionController : Controller
    {
        private ILogin LoginUC;

        public AutorizacionController(ILogin loginUC)
        {
            LoginUC = loginUC;
        }
 

        public ActionResult Login()
        {
             return View();    
        }
        [HttpPost]
        public ActionResult Login(string Alias, string Contrasenia)
        {
           

            if (LoginUC.IniciarSesion(Alias, Contrasenia))
            {
              HttpContext.Session.SetString("LogueadoAlias", Alias);
               //HttpContext.Session.SetString("Token", Token);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.msg = "Datos incorrectos";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Autorizacion");
        }

        

        

    }
}
