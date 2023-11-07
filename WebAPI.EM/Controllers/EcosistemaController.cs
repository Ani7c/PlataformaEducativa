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


        //Obtiene todos los ecosistemas
        [HttpGet(Name = "GetEcosistema")]

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


        //Crea un ecosistema
        [HttpPost()]
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
