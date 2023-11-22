using LogicaAplicacion.InterfaceUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenazaController : ControllerBase
    {
        private IGetThreats GetThreatsUC;
        private IGetAmenazaById GetAmenazaByIdUC;

        public AmenazaController(IGetThreats getThreatsUC, IGetAmenazaById getAmenazaByIdUC)
        {
            GetThreatsUC = getThreatsUC;
            GetAmenazaByIdUC = getAmenazaByIdUC;
        }

        /// <summary>
        /// Obtiene todas las amenazas cargadas en el sistema
        /// </summary>
        /// <returns> Lista de todas las amenazas </returns>
        [HttpGet(Name = "GetAmenazas")]

        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Get()
        {
            try
            {
                return Ok(this.GetThreatsUC.GetAmenazas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
