using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private IUpdateSettings UpdateSettingsUC;
        private IGetSettings GetSettingsUC;
        private IFindSettingsByName GetSettingsByNameUC;

        public ConfiguracionController(IUpdateSettings updateSettingsUC, IGetSettings getSettingsUC, IFindSettingsByName getSettingsByNameUC)
        {
            UpdateSettingsUC = updateSettingsUC;
            GetSettingsUC = getSettingsUC;
            GetSettingsByNameUC = getSettingsByNameUC;
        }

        /// <summary>
        /// Obtiene todas las configuraciones cargadas en el sistema
        /// </summary>
        /// <returns> Lista de todas las Configuraciones </returns>
        [HttpGet(Name = "GetConfiguraciones")]

        [ProducesResponseType(StatusCodes.Status200OK)]


        public IActionResult Get()
        {
            try
            {
                return Ok(this.GetSettingsUC.GetSettings());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Permite editar los topes
        /// </summary>
        /// <param name="configuracion"></param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update(ConfiguracionDTO configuracion)
        {
            try
            {
                this.UpdateSettingsUC.UpdateSettings(configuracion);
                return Ok(configuracion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
