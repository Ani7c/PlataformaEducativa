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

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login([FromBody] UsuarioDTO usuario)
        {
            try
            {
                TokenHandler tokenHandler = new TokenHandler(this._obtenerUsuario);
                var user = tokenHandler.ObtenerUsuario(usuario.Alias, usuario.Contrasenia);

                if (user == null)
                    return Unauthorized("Nombre de usuario o contrasenia incorrecta.");

                var token = TokenHandler.GenerarToken(usuario, this._configuration);
                return Ok(new
                {
                    Token = token,
                    Usuario = usuario
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
