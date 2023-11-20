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
        private IGetAmenazaById GetAmenazaByIdUC;
        private IGetEstadosConservacion GetEstadosConservacionUC;
        private IUpdateEcosystem UpdateEcosystemUC;

        public EcosistemaController(IAddEcosystem addEcosystemUC, IGetEcosystem getEcosystemUC, 
            IGetThreats getThreatsUC, IGetCountries getCountriesUC, IObtenerPaisPorCodigo obtenerPaisPorCodigoUC, 
            IWebHostEnvironment environment, IGetEcosystemById getEcosystemByIdUC, IRemoveById removeByIdUC, 
            IAddChangeTracking addChangeTrackingUC, IGetAmenazaById getAmenazaByIdUC, IGetEstadosConservacion getEstadosConservacionUC
            , IUpdateEcosystem updateEcosystemUC)
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
            GetAmenazaByIdUC = getAmenazaByIdUC;
            GetEstadosConservacionUC = getEstadosConservacionUC;
            UpdateEcosystemUC = updateEcosystemUC;
        }



        // GET: EcosistemaController
        public ActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View(GetEcosystemUC.GetEcosystems());
        }

        

        // GET: EcosistemaController/Create
        public ActionResult Create(string mensaje)
        {
            string alias = HttpContext.Session.GetString("LogueadoAlias");
            if(alias != null){
                ViewBag.Mensaje = mensaje;
                ViewBag.Amenazas = this.GetThreatsUC.GetAmenazas();
                ViewBag.Paises = this.GetCountriesUC.GetCountries();
                ViewBag.Estados = this.GetEstadosConservacionUC.GetEstadosConservacion();
                return View(); 
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: EcosistemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EcosistemaMarino em, List<int> amenazaIds, IFormFile imagen)
            {
            try
            {
                Pais pais = ObtenerPaisPorCodigoUC.BuscarPorCodigo(em.codPais);
                em.Pais = pais;

                em._amenazas = new List<Amenaza>();
                foreach (int amenazaId in amenazaIds)
                {
                    Amenaza amenaza = this.GetAmenazaByIdUC.FindById(amenazaId);
                    if (amenaza != null)
                    {
                        em._amenazas.Add(amenaza);
                    }
                }

                //AGREGARMOS ECOSISTEMA
                em.ImgEcosistema = "SinNombreAun";
 //               this.AddEcosystemUC.AddEcosystem(em);

                //REGISTRAMOS CAMBIOS
                //GuardarCambiosEcosistema(em);
                ControlDeCambios cambios = new ControlDeCambios();
                cambios.IdEntidad = em.IdEcosistema;
                cambios.TipoEntidad = em.ToString();
                cambios.NombreUsuario = HttpContext.Session.GetString("LogueadoAlias")

                //this.AddChangeTrackingUC.AddChangeTracking(cambios);



                //GUARDAMOS IMAGEN
                if (em == null || imagen == null) return View();

                if (GuardarImagen(imagen, em))
                {
                    this.UpdateEcosystemUC.UpdateEcosystem(em);
                    return RedirectToAction("Index");

                }
                //this.AddEcosystemUC.AddEcosystem(em);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Create), new { mensaje = e.Message });
            }
        }

        //private void GuardarCambiosEcosistema(EcosistemaMarino em)
        //{
        //    if (HttpContext.Session.GetString("LogueadoAlias") != null)
        //    {
        //        //REGISTRAMOS CAMBIOS
        //        ControlDeCambios cambios = new ControlDeCambios
        //        {
        //            NombreUsuario = HttpContext.Session.GetString("LogueadoAlias"),
        //            TipoEntidad = em.ToString(),
        //            IdEntidad = em.IdEcosistema

        //        };
        //        this.AddChangeTrackingUC.AddChangeTracking(cambios);
        //    }
        //}

        private bool GuardarImagen(IFormFile imagen, EcosistemaMarino em)
        {
            if (imagen == null || em == null) return false;
            // SUBIR LA IMAGEN
            //ruta física de wwwroot
            string rutaFisicaWwwRoot = _environment.WebRootPath;

            string extension = Path.GetExtension(imagen.FileName);
            string nombreImagen = em.IdEcosistema + "_001"+ extension;
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
                string alias = HttpContext.Session.GetString("LogueadoAlias");
                if (alias != null)
                {
                    return View(this.GetEcosystemByIdUC.GetEcosystemById(id));
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                    
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
                //REGISTRAMOS CAMBIOS
            //    GuardarCambiosEcosistema(GetEcosystemByIdUC.GetEcosystemById(id));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index), new { mensaje = e.Message });
            }
        }
    }
}
