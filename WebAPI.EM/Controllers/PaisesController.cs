using Ecosistemas_Marinos.Interfaces_Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private IRepositorioPais repositorioPais;
        public PaisesController(IRepositorioPais repositorioPais)
        {
            this.repositorioPais = repositorioPais;
        }

        /// <summary>
        /// Obtengo todos los Paises cargados en la BBDD
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetPaises")]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.repositorioPais.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
