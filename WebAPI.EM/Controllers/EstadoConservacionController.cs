using LogicaAplicacion.InterfaceUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoConservacionController : ControllerBase
    {

        private IGetEstadosConservacion GetEstadosConservacionUC;

        public EstadoConservacionController(IGetEstadosConservacion getEstadosConservacionUC)
        {
            GetEstadosConservacionUC = getEstadosConservacionUC;
        }

        /// <summary>
        /// Obtiene todos los estados de conservacion cargados en el sistema
        /// </summary>
        /// <returns> Lista de todos los estados de conservacion </returns>
        [HttpGet(Name = "GetEstados")]

        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Get()
        {
            try
            {
                return Ok(this.GetEstadosConservacionUC.GetEstadosConservacion());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
