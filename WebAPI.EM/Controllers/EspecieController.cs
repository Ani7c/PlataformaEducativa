using LogicaAplicacion.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
       
        [HttpGet(Name ="GetEcosistemas")]

        public IActionResult Get() { 
            return Ok();
        }

        [HttpPost()]
        public IActionResult Post([FromBody] EspecieDTO especie) 
        {
            try
            {
                EspecieDTO especieDTO = this.AddSpeciesUC.AddSpecie(especie);
                return Created("api/Especies", especieDTO);
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }
    }
}
