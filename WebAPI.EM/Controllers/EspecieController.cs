using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
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


        /// <summary>
        /// Obtiene todas las especies marinas cargadas en el sistema
        /// </summary>
        /// <returns> Lista de todas las especies marinas </returns>
        [HttpGet(Name ="GetEspecies")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            try { 
                return Ok(this.GetSpeciesUC.GetSpecies());
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtiene los detalles de la especie marina
        /// </summary>
        /// <param name="especieId"></param>
        /// <returns> Los detalles de la especie marina </returns>
        [HttpGet("{especieId}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDetails(int especieId)
        {
            try
            {
                return Ok(this.GetSpecieByIdUC.FindById(especieId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Agrega una especie a la base de datos
        /// </summary>
        /// <param name="especie"></param>
        /// <returns></returns>
        [HttpPost()]

        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] EspecieDTO especie) 
        {
            try
            {
                AddSpeciesUC.AddSpecies(especie);

                //Guardamos los cambios
                ControlDeCambiosDTO cambios = new ControlDeCambiosDTO();
                cambios.NombreUsuario = HttpContext.Session.GetString("LogueadoAlias");
                cambios.IdEntidad = especie.Id;
                cambios.TipoEntidad = "EspecieMarina";
                this.AddChangeTrackingUC.AddChangeTracking(cambios);

                return Created("api/Especies", especie);
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }

        //[HttpGet(Name = "Filtrado")]
        //public IActionResult Filtrado()
        //{
        //    //string? lAlias = HttpContext.Session.GetString("LogueadoAlias");
        //    //if (lAlias != null)
        //    //{
        //    return Ok(this.GetEcosystemUC.GetEcosystems());
        //    //}
        //    //else
        //    //{
        //    //    ViewBag.msg = "No autorizado";
        //    //    return View();
        //    //}
        //}

        //[HttpPost(Name = "ResultadoFiltrado")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Post(string NombreCientifico, bool enPeligroExtincion, double pesoMinimo, double pesoMaximo, int IdEcosistema)
        //{

        //    var resultados = this.FiltradoUC.GetSpeciesBy(NombreCientifico, enPeligroExtincion, pesoMinimo, pesoMaximo, IdEcosistema);
        //    return Ok(resultados);
        //}


        //[HttpPost(Name = "FiltrarDadaUnaEspecie")]

        //public IActionResult Post(int IdEspecie)
        //{
        //    var resultados = this.FiltrarDadaUnaEspecieUC.FiltrarDadaUnaEspecie(IdEspecie);
        //    return Ok(resultados);
        //}




        //public ActionResult Asociar()
        //{
        //    string alias = HttpContext.Session.GetString("LogueadoAlias");
        //    if (alias != null)
        //    {
        //        ViewBag.Especies = this.GetSpeciesUC.GetSpecies();//todas las especies
        //        ViewBag.Ecosistemas = this.GetPosiblesEcosistemasUC.GetPosiblesEcosistemas(); //los posibles ecosistemas de la lista en especie
        //        return Ok();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        //[HttpPost (Name = "Asociar")]
        //public ActionResult Asociar(int EspecieId, int EcosistemaId)
        //{
        //    try
        //    {
        //        // EspecieMarina especie = this.GetSpecieByIdUC.GetEspecieMarina(EspecieId);
        //        // EcosistemaMarino ecosistema = this.GetEcosystemByIdUC.GetEcosystemById(EcosistemaId);
        //        //llamar a asociar
        //        this.AddSpecieToEcosystemUC.AsociarEspecieAEcosistema(EspecieId, EcosistemaId);
        //        //GUARDAMOS CAMBIOS
        //        // GuardarCambiosEspecie(GetSpecieByIdUC.FindById(EspecieId));
        //        return RedirectToAction(nameof(Index), new { mensaje = "Asociados exitosamente" });
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

    }
}
