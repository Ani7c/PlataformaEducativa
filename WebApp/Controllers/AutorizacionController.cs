using Ecosistemas_Marinos.Entidades;
using LogicaAplicacion.InterfaceUseCase;
using LogicaAplicacion.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            //if es true

            if (LoginUC.IniciarSesion(Alias, Contrasenia))
            {
              HttpContext.Session.SetString("LogueadoAlias", Alias);  
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

        // GET: AutorizacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AutorizacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AutorizacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorizacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorizacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AutorizacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorizacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AutorizacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
