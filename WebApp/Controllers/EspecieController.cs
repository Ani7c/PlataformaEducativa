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
        private IGetThreats GetThreatsUC;
        private IGetAmenazaById GetAmenazaByIdUC;
        private IGetEstadosConservacion GetEstadosConservacionUC;
        private IUpdateSpecie UpdateSpecieUC;
        private IAddChangeTracking AddChangeTrackingUC;
        private IGetSpecieById GetSpecieByIdUC;
        private IFiltrarDadaUnaEspecie FiltrarDadaUnaEspecieUC;

        public EspecieController(IWebHostEnvironment environment, IAddSpecies addSpeciesUC,
            IGetSpecies getSpeciesUC, IGetEcosystem getEcosystemUC, IGetEcosystemById getEcosystemByIdUC,
            IAddSpecieToEcosystem addSpecieToEcosystemUC, IGetEspeciesPorNombre getEspeciesPorNombreUC,
            IGetPosiblesEcosistemas getPosiblesEcosistemas, IFiltrado filtradoUC, IGetThreats getThreatsUC,
            IGetAmenazaById getAmenazaByIdUC, IGetEstadosConservacion getEstadosConservacionUC,
             IUpdateSpecie updateSpecieUC, IAddChangeTracking addChangeTrackingUC, IGetSpecieById getSpecieByIdUC,
             IFiltrarDadaUnaEspecie filtrarDadaUnaEspecieUC)
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
            GetThreatsUC = getThreatsUC;
            GetAmenazaByIdUC = getAmenazaByIdUC;
            GetEstadosConservacionUC = getEstadosConservacionUC;
            UpdateSpecieUC = updateSpecieUC;
            AddChangeTrackingUC = addChangeTrackingUC;
            GetSpecieByIdUC = getSpecieByIdUC;
            FiltrarDadaUnaEspecieUC = filtrarDadaUnaEspecieUC;
        }


        // GET: EspecieController
        public ActionResult Index()
        {
            return View(this.GetSpeciesUC.GetSpecies());
        }

        

        // GET: EspecieController/Create
        public ActionResult Create(string mensaje)
        {
            string alias = HttpContext.Session.GetString("LogueadoAlias");
            if(alias != null)
            {
                ViewBag.Amenazas = this.GetThreatsUC.GetAmenazas();
                ViewBag.Mensaje = mensaje;
                ViewBag.Ecosistemas = this.GetEcosystemUC.GetEcosystems();
                ViewBag.Estados = this.GetEstadosConservacionUC.GetEstadosConservacion();
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: EspecieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecieMarina especie, List<int> ecoIds, List<int> amenazaIds, IFormFile imagen)
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

                especie._amenazas = new List<Amenaza>();
                foreach(int amenazaId in amenazaIds)
                {
                    Amenaza amenaza = this.GetAmenazaByIdUC.FindById(amenazaId);
                    if( amenaza != null)
                    {
                        especie._amenazas.Add(amenaza);
                    }
                }

                //GUARDAMOS ESPECIE
                especie.ImgEspecie = "sinNombreAun";
                //this.AddSpeciesUC.AddSpecies(especie);

                //GUARDAMOS CAMBIOS
                GuardarCambiosEspecie(especie);

                //GUARDAMOS IMAGEN
                if (especie == null || imagen == null) return View();

                if (GuardarImagen(imagen, especie))
                {
                    this.UpdateSpecieUC.UpdateSpecie(especie);
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

            string extension = Path.GetExtension(imagen.FileName);
            string nombreImagen = especie.Id + "_001"+ extension;
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
        
        private void GuardarCambiosEspecie(EspecieMarina es)
        {        
            if (HttpContext.Session.GetString("LogueadoAlias") != null)
            {
                //REGISTRAMOS CAMBIOS
                ControlDeCambios cambios = new ControlDeCambios
                {
                    NombreUsuario = HttpContext.Session.GetString("LogueadoAlias"),
                    TipoEntidad = es.ToString(),
                    IdEntidad = es.Id

                };
                //this.AddChangeTrackingUC.AddChangeTracking(cambios);
            }
        }

        public IActionResult Filtrado()
        { 
                ViewBag.Ecosistemas = this.GetEcosystemUC.GetEcosystems();
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filtrado(string NombreCientifico, bool enPeligroExtincion, double pesoMinimo, double pesoMaximo, int IdEcosistema)
        {
          
        }


        public IActionResult FiltrarDadaUnaEspecie()
        {
            ViewBag.Especies = this.GetSpeciesUC.GetSpecies();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FiltrarDadaUnaEspecie(int IdEspecie)
        {
            var resultados = this.FiltrarDadaUnaEspecieUC.FiltrarDadaUnaEspecie(IdEspecie);
            return View("EcosistemasDadaUnaEspecie", resultados);
        }



       

        public ActionResult Asociar()
        {
            string alias = HttpContext.Session.GetString("LogueadoAlias");
            if (alias != null)
            {
                ViewBag.Especies = this.GetSpeciesUC.GetSpecies();//todas las especies
                ViewBag.Ecosistemas = this.GetPosiblesEcosistemasUC.GetPosiblesEcosistemas() ; //los posibles ecosistemas de la lista en especie
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
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
                //GUARDAMOS CAMBIOS
               // GuardarCambiosEspecie(GetSpecieByIdUC.FindById(EspecieId));
                return RedirectToAction(nameof(Index), new { mensaje = "Asociados exitosamente" });
            }
            catch
            {
                return View();
            }
        }
    }
}
