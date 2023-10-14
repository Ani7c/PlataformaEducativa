using EcosistemasMarinos.Entidades;
using LogicaAplicacion.InterfaceUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class EspecieController : Controller
    {
        private IAddSpecies AddSpeciesUC;

        public EspecieController(IAddSpecies AddSpeciesUC)
        {
            AddSpeciesUC = AddSpeciesUC;
        }


        // GET: EspecieController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EspecieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EspecieController/Create
        public ActionResult Create(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        // POST: EspecieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecieMarina especie)
        {
            try
            {
                this.AddSpeciesUC.AddSpecies(especie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create), new { mensaje = "La especie ya existe" });
            }
        }

        // GET: EspecieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EspecieController/Edit/5
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

        // GET: EspecieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EspecieController/Delete/5
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
