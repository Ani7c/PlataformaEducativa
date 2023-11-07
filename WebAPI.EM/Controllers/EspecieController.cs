using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
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

        [HttpGet(Name ="GetEcosistemas")]

        public IActionResult Get() { 
            return Ok();
        }

        [HttpPost()]
        public IActionResult Post([FromBody] EspecieDTO especie) 
        {
            try
            {
                AddSpeciesUC.AddSpecies(especie);
                return Created("api/Especies", especie);
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }
    }
}
