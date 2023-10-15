﻿using Ecosistemas_Marinos.Entidades;
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

        public EcosistemaController(IAddEcosystem addEcosystemUC, IGetEcosystem getEcosystemUC, 
            IGetThreats getThreatsUC, IGetCountries getCountriesUC, IObtenerPaisPorCodigo obtenerPaisPorCodigoUC, 
            IWebHostEnvironment environment)
        {
            AddEcosystemUC = addEcosystemUC;
            GetEcosystemUC = getEcosystemUC;
            GetThreatsUC = getThreatsUC;
            GetCountriesUC = getCountriesUC;
            ObtenerPaisPorCodigoUC = obtenerPaisPorCodigoUC;
            _environment = environment;
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
            ViewBag.Amenazas = this.GetThreatsUC.GetAmenazas();
            ViewBag.Paises = this.GetCountriesUC.GetCountries();
            return View(); 
        }

        // POST: EcosistemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EcosistemaMarino em, List<string> paisesCods, IFormFile imagen)
            {
            try
            {
                if (imagen == null || !ModelState.IsValid) return View();

                if (GuardarImagen(imagen, em))
                {

                    em.Paises = new List<Pais>();
                    foreach (string paisCod in paisesCods)
                    {
                        Pais pais = ObtenerPaisPorCodigoUC.BuscarPorCodigo(paisCod);
                        if (pais != null)
                        {
                            em.Paises.Add(pais);
                        }
                    }
                    this.AddEcosystemUC.AddEcosystem(em);
                }
              
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

            //imagen.FileName = em.Nombre + em.Id algo asi 
            string nombreImagen = imagen.FileName;
            //ruta donde se guardan las fotos de las personas
            string rutaFisicaFoto = Path.Combine
            (rutaFisicaWwwRoot, "imagenes", "Ecosistemas", nombreImagen);
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
                p.NombreArchivoFoto = nombreImagen;
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
            return View();
        }

        // POST: EcosistemaController/Delete/5
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
