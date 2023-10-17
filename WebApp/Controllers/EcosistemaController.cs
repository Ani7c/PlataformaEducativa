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
    public class EcosistemaController : Controller
    {
        private IWebHostEnvironment _environment;
        private IAddEcosystem AddEcosystemUC;
        private IGetEcosystem GetEcosystemUC;
        private IGetThreats GetThreatsUC;
        private IGetCountries GetCountriesUC;
        private IObtenerPaisPorCodigo ObtenerPaisPorCodigoUC;
        private IGetEcosystemById GetEcosystemByIdUC;
        private IRemoveById RemoveByIdUC;
        private IAddChangeTracking AddChangeTrackingUC;

        public EcosistemaController(IAddEcosystem addEcosystemUC, IGetEcosystem getEcosystemUC, 
            IGetThreats getThreatsUC, IGetCountries getCountriesUC, IObtenerPaisPorCodigo obtenerPaisPorCodigoUC, 
            IWebHostEnvironment environment, IGetEcosystemById getEcosystemByIdUC, IRemoveById removeByIdUC, IAddChangeTracking addChangeTrackingUC)
        {
            AddEcosystemUC = addEcosystemUC;
            GetEcosystemUC = getEcosystemUC;
            GetThreatsUC = getThreatsUC;
            GetCountriesUC = getCountriesUC;
            ObtenerPaisPorCodigoUC = obtenerPaisPorCodigoUC;
            _environment = environment;
            GetEcosystemByIdUC = getEcosystemByIdUC;
            RemoveByIdUC = removeByIdUC;
            AddChangeTrackingUC = addChangeTrackingUC;
        }



        // GET: EcosistemaController
        public ActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View(GetEcosystemUC.GetEcosystems());
        }

        // GET: EcosistemaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EcosistemaController/Create
        public ActionResult Create(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            //ViewBag.Amenazas = this.GetThreatsUC.GetAmenazas();
            ViewBag.Paises = this.GetCountriesUC.GetCountries();
            return View(); 
        }

        // POST: EcosistemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EcosistemaMarino em, IFormFile imagen)
            {
            try
            {
                Pais pais = ObtenerPaisPorCodigoUC.BuscarPorCodigo(em.codPais);
                em.Pais = pais;

                if (HttpContext.Session.GetString("LogueadoAlias") != null) { 
                    //REGISTRAMOS CAMBIOS
                    ControlDeCambios cambios = new ControlDeCambios
                    {
                        NombreUsuario = HttpContext.Session.GetString("LogueadoAlias"),
                        TipoEntidad = em.ToString(),
                        IdEntidad = em.IdEcosistema

                    };
                    this.AddChangeTrackingUC.AddChangeTracking(cambios);
                }
                

                //GUARDAMOS IMAGEN
                if (em == null || imagen == null) return View();

                if (GuardarImagen(imagen, em))
                {
                    this.AddEcosystemUC.AddEcosystem(em);
                    return RedirectToAction("Index");

                }
                //this.AddEcosystemUC.AddEcosystem(em);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Create), new { mensaje = $"Ecosistema ya existente" + ex});
            }
        }


        private bool GuardarImagen(IFormFile imagen, EcosistemaMarino em)
        {
            if (imagen == null || em == null) return false;
            // SUBIR LA IMAGEN
            //ruta física de wwwroot
            string rutaFisicaWwwRoot = _environment.WebRootPath;

            //ver como hacer para que se mantenga la extension jpg, etc
            string nombreImagen = em.IdEcosistema + "_001";
            //ruta donde se guardan las fotos de las personas
            string rutaFisicaFoto = Path.Combine
            (rutaFisicaWwwRoot, "img", "Ecosistemas", nombreImagen);
            //FileStream permite manejar archivos
            try
            {
                //el método using libera los recursos del objeto FileStream al finalizar
                using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                {
                    //Para archivos grandes o varios archivos usar la versión
                    //asincrónica de CopyTo. Sería: await imagen.CopyToAsync (f);
                    imagen.CopyTo(f);
                }
                //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                em.ImgEcosistema = nombreImagen;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        // GET: EcosistemaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EcosistemaController/Edit/5
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

        // GET: EcosistemaController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(this.GetEcosystemByIdUC.GetEcosystemById(id));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index), new { mensaje = e.Message });
            }
        }

        // POST: EcosistemaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                this.RemoveByIdUC.RemoveById(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index), new { mensaje = e.Message });
            }
        }
    }
}
