using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPI.EM
{
    public class TokenHandler
    {
        private IObtenerUsuario _obtenerUsuario;

        public TokenHandler(IObtenerUsuario obtenerUsuario)
        {
            this._obtenerUsuario = obtenerUsuario;
        }   

        public static string GenerarToken(UsuarioDTO usuario, IConfiguration configuration)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, usuario.Alias)
            };

            var claveSecreta = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                GetBytes(configuration.GetSection("AppSettings:SecretTokenKey").Value!));

            var credenciales = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

        public UsuarioDTO ObtenerUsuario(string alias, string password)
        {
            return _obtenerUsuario.ObtenerUsuario(alias, password);
        }

        
    }
}
