using Ecosistemas_Marinos.Interfaces_Repositorios;
using LogicaAplicacion.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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


        [HttpPost]
        public IActionResult GuardarPaises([FromBody] IEnumerable<PaisDTO> paises)
        {
            try
            {
                // Aquí puedes guardar los países en tu base de datos o realizar otras operaciones necesarias
                // ...

                return Ok(); // Puedes devolver un Ok() si la operación fue exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir durante el procesamiento
                return BadRequest($"Error: {ex.Message}");
            }
        }


    }
}
