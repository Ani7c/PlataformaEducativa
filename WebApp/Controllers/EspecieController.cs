using Ecosistemas_Marinos.Entidades;
using EcosistemasMarinos.Entidades;
using LogicaAplicacion.InterfaceUseCase;
using LogicaAplicacion.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//upload img
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace WebApp.Controllers
{
    public class EspecieController : Controller
    {
        private IWebHostEnvironment _environment;
        private IAddSpecies AddSpeciesUC;
        private IGetSpecies GetSpeciesUC;
        private IGetEcosystem GetEcosystemUC;
        private IGetEcosystemById GetEcosystemByIdUC;
        private IAddSpecieToEcosystem AddSpecieToEcosystemUC;
        private IGetEspeciesPorNombre GetEspeciesPorNombreUC;
        private IGetPosiblesEcosistemas GetPosiblesEcosistemasUC;
        private IFiltrado FiltradoUC;

        public EspecieController(IWebHostEnvironment environment, IAddSpecies addSpeciesUC, IGetSpecies getSpeciesUC, IGetEcosystem getEcosystemUC, IGetEcosystemById getEcosystemByIdUC, IAddSpecieToEcosystem addSpecieToEcosystemUC, IGetEspeciesPorNombre getEspeciesPorNombreUC, IGetPosiblesEcosistemas getPosiblesEcosistemas , IFiltrado filtradoUC)
        {
            _environment = environment;
            AddSpeciesUC = addSpeciesUC;
            GetSpeciesUC = getSpeciesUC;
            GetEcosystemUC = getEcosystemUC;
            GetEcosystemByIdUC = getEcosystemByIdUC;
            AddSpecieToEcosystemUC = addSpecieToEcosystemUC;
            GetEspeciesPorNombreUC = getEspeciesPorNombreUC;
            GetPosiblesEcosistemasUC = getPosiblesEcosistemas;
            FiltradoUC = filtradoUC;
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
        public ActionResult Create(EspecieMarina especie, List<int> ecoIds, IFormFile imagen)
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
                //GUARDAMOS IMAGEN
                if (especie == null || imagen == null) return View();

                if (GuardarImagen(imagen, especie))
                {
                    this.AddSpeciesUC.AddSpecies(especie);
                    return RedirectToAction("Index");

                }
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create), new { mensaje = "La especie ya existe" });
            }
        }

        private bool GuardarImagen(IFormFile imagen, EspecieMarina especie)
        {
            if (imagen == null || especie == null) return false;
            // SUBIR LA IMAGEN
            //ruta física de wwwroot
            string rutaFisicaWwwRoot = _environment.WebRootPath;

            //ver como hacer para que se mantenga la extension jpg, etc
            string nombreImagen = especie.Id + "_001";
            //ruta donde se guardan las fotos de las personas
            string rutaFisicaFoto = Path.Combine
            (rutaFisicaWwwRoot, "img", "Especies", nombreImagen);
       
            try
            {
                //el método using libera los recursos del objeto FileStream al finalizar
                using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                {
                    
                    imagen.CopyTo(f);
                }
                //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                especie.ImgEspecie = nombreImagen;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IActionResult Filtrado()
        {
            //string? lAlias = HttpContext.Session.GetString("LogueadoAlias");
            //if (lAlias != null)
            //{
                ViewBag.Ecosistemas = this.GetEcosystemUC.GetEcosystems();
                return View();
            //}
            //else
            //{
            //    ViewBag.msg = "No autorizado";
            //    return View();
            //}
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filtrado(string NombreCientifico, bool enPeligroExtincion, double pesoMinimo, double pesoMaximo, int IdEcosistema)
        {

            var resultados = this.FiltradoUC.GetSpeciesBy(NombreCientifico, enPeligroExtincion, pesoMinimo, pesoMaximo, IdEcosistema);
            return View("ResultadoFiltrado", resultados);
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
            ViewBag.Ecosistemas = this.GetPosiblesEcosistemasUC.GetPosiblesEcosistemas() ; //los posibles ecosistemas de la lista en especie
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Asociar(int EspecieId, int EcosistemaId)
        {
            try
            {
               // EspecieMarina especie = this.GetSpecieByIdUC.GetEspecieMarina(EspecieId);
               // EcosistemaMarino ecosistema = this.GetEcosystemByIdUC.GetEcosystemById(EcosistemaId);
                //llamar a asociar
                this.AddSpecieToEcosystemUC.AsociarEspecieAEcosistema(EspecieId, EcosistemaId);
                return RedirectToAction(nameof(Index), new { mensaje = "Asociados exitosamente" });
            }
            catch
            {
                return View();
            }
        }
    }
}
