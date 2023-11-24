using Ecosistemas_Marinos.Entidades;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace WebAPI.EM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration { get; set; }
        private IObtenerUsuario _obtenerUsuario { get; set; }   

        public LoginController(IConfiguration configuration, IObtenerUsuario obtenerUsuario)
        {
            this._configuration = configuration;
            this._obtenerUsuario = obtenerUsuario;
        }

        /// <summary>
        /// Autentica un usuario y genera un token de acceso JWT.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioDTO usuario)
        {
            try
            {
                TokenHandler tokenHandler = new TokenHandler(this._obtenerUsuario);
                var user = tokenHandler.ObtenerUsuario(usuario.Alias, usuario.Contrasenia);                 
                var token = TokenHandler.GenerarToken(usuario, this._configuration);
                usuario.Token = token;
                return Ok(usuario);
            }

            catch (Exception)
            {
                return BadRequest("Nombre de usuario o contraseña incorrecta.");
            
            }
        }
    }
}
