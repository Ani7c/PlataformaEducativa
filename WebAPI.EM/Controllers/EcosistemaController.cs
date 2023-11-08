using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using LogicaAplicacion.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcosistemaController : ControllerBase
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


        /// <summary>
        /// Obtiene todos los ecosistemas cargados en el sistema
        /// </summary>
        /// <returns> Lista de todos los ecosistemas </returns>
        [HttpGet(Name = "GetEcosistema")]

        [ProducesResponseType(StatusCodes.Status200OK)]


        public IActionResult Get()
        {
            try
            {
                return Ok(this.GetEcosystemUC.GetEcosystems());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Agrega un ecosistema a la base de datos
        /// </summary>
        /// <param name="ecosistema"></param>
        /// <returns></returns>
        [HttpPost()]

        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] EcosistemaDTO ecosistema)
        {
            try
            {
                AddEcosystemUC.AddEcosystem(ecosistema);
                return Created("api/Ecosistemas", ecosistema);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
