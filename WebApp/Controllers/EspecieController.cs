using Ecosistemas_Marinos.Entidades;
using EcosistemasMarinos.Entidades;
using LogicaAplicacion.InterfaceUseCase;
using LogicaAplicacion.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class EspecieController : Controller
    {
        private IAddSpecies AddSpeciesUC;
        private IGetSpecies GetSpeciesUC;
        private IGetEcosystem GetEcosystemUC;
        private IGetEcosystemById GetEcosystemByIdUC;
        private IAddSpecieToEcosystem AddSpecieToEcosystemUC;
        private IGetEspeciesPorNombre GetEspeciesPorNombreUC;

        public EspecieController(IAddSpecies addSpeciesUC, IGetSpecies getSpeciesUC, IGetEcosystem getEcosystemUC, IGetEcosystemById getEcosystemByIdUC, IAddSpecieToEcosystem addSpecieToEcosystemUC, IGetEspeciesPorNombre getEspeciesPorNombreUC)
        {
            AddSpeciesUC = addSpeciesUC;
            GetSpeciesUC = getSpeciesUC;
            GetEcosystemUC = getEcosystemUC;
            GetEcosystemByIdUC = getEcosystemByIdUC;
            AddSpecieToEcosystemUC = addSpecieToEcosystemUC;
            GetEspeciesPorNombreUC = getEspeciesPorNombreUC;
        }


        // GET: EspecieController
        public ActionResult Index()
        {
            return View(this.GetSpeciesUC.GetSpecies());
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
            ViewBag.Ecosistemas = this.GetEcosystemUC.GetEcosystems();
            return View();
        }

        // POST: EspecieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecieMarina especie, List<int> ecoIds)
        {
            try
            {
                especie._ecosistemas = new List<EcosistemaMarino>();
                foreach (int ecoId in ecoIds)
                {
                    EcosistemaMarino ecosistema = GetEcosystemByIdUC.GetEcosystemById(ecoId);
                    if (ecosistema != null)
                    {
                        especie._ecosistemas.Add(ecosistema);
                    }
                }
                this.AddSpeciesUC.AddSpecies(especie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create), new { mensaje = "La especie ya existe" });
            }
        }

        public IActionResult FiltrarPorNombreCientifico()
        {
            string? lAlias = HttpContext.Session.GetString("LogueadoAlias");
            if (lAlias != null)
            {
                return View();
            }
            else
            {
                ViewBag.msg = "No autorizado";
                return View();
            }
        }

        [HttpPost]
        public IActionResult FiltrarPorNombreCientifico(string NombreCientifico)
        {
            List<EspecieMarina> ret = this.GetEspeciesPorNombreUC.GetEspeciesPorNombre(NombreCientifico);
            
            return View(ret);
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

        public ActionResult Asociar()
        {
            ViewBag.Especies = this.GetSpeciesUC.GetSpecies();//todas las especies
            ViewBag.Ecosistemas = ;//los posibles ecosistemas de la lista en especie
            return View();
        }
    }
}
