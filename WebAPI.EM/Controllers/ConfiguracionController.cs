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


        //Edit
        [HttpPut()]
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
