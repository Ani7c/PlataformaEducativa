using Ecosistemas_Marinos.Interfaces_Repositorios;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.EM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private IGuardarPaises GuardarPaisesUC;

        public PaisesController(IGuardarPaises guardarPaisesUC)
        {
            GuardarPaisesUC = guardarPaisesUC;
        }

        /// <summary>
        /// Guarda en la base de datos los paises obtenidos desde REST Countries
        /// </summary>
        /// <param name="paises"></param>
        /// <returns></returns>
        [HttpPost]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GuardarPaises([FromBody] IEnumerable<PaisDTO> paises)
        {
            try
            {
                // Aquí puedes guardar los países en tu base de datos o realizar otras operaciones necesarias
                // TODO Belen hace GuardarPaisesUC, Ana hace GuardarPaises en el RepositorioPais
                // this.GuardarPaisesUC.GuardarPaises(paises);

                return Ok(); 
                //No se si es un Ok ya que es un post, sera un Created?
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


    }
}
