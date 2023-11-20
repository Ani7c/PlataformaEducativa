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

        /// <summary>
        /// Obtiene la lista filtrada de especies
        /// </summary>
        /// <param name="NombreCientifico"></param>
        /// <param name="enPeligroExtincion"></param>
        /// <param name="pesoMinimo"></param>
        /// <param name="pesoMaximo"></param>
        /// <param name="IdEcosistema"></param>
        /// <returns>Lista de especies</returns>
        /// 
        [HttpGet("{Filtrado}")]
        [ValidateAntiForgeryToken]
        public IActionResult Filtrado(string NombreCientifico, bool enPeligroExtincion, double pesoMinimo, double pesoMaximo, int IdEcosistema)
        {
            try
            {
                var resultados = this.FiltradoUC.GetSpeciesBy(NombreCientifico, enPeligroExtincion, pesoMinimo, pesoMaximo, IdEcosistema);
                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{FiltrarDadaUnaEspecie}")]

        public IActionResult Get(int idEspecie)
        {
            var resultados = this.FiltrarDadaUnaEspecieUC.FiltrarDadaUnaEspecie(idEspecie);
            return Ok(resultados);
        }



        [HttpPost("{Asociar}")]
        public ActionResult Asociar(int EspecieId, int EcosistemaId)
        {
            try
            {
                //llamar a asociar
                this.AddSpecieToEcosystemUC.AsociarEspecieAEcosistema(EspecieId, EcosistemaId);

                //GUARDAMOS CAMBIOS
                ControlDeCambiosDTO cambios = new ControlDeCambiosDTO();
                cambios.NombreUsuario = HttpContext.Session.GetString("LogueadoAlias");
                cambios.IdEntidad = EcosistemaId;
                cambios.TipoEntidad = "EcosistemaMarino";
                this.AddChangeTrackingUC.AddChangeTracking(cambios);

                return RedirectToAction(nameof(Index), new { mensaje = "Asociados exitosamente" });
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
