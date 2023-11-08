using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using LogicaAplicacion.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IAddUser AddUserUC;
        private IAddChangeTracking AddChangeTrackingUC;

        public UsuarioController(IAddUser addUserUC, IAddChangeTracking addChangeTrackingUC)
        {
            AddUserUC = addUserUC;
            AddChangeTrackingUC = addChangeTrackingUC;
        }


        /// <summary>
        /// Agrega un usuario a la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost()]

        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] UsuarioDTO usuario)
        {
            try
            {
                AddUserUC.AddUser(usuario);
                return Created("api/Usuarios", usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
