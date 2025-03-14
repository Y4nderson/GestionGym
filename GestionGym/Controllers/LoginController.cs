using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GestionGym.Modelos;
using GestionGym.Repositosios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GestionGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly LoginRepositorio _loginRepositorio;
        private string claveSecreta;
        public LoginController(LoginRepositorio loginRepositorio, IConfiguration configuration)
        {
            _loginRepositorio = loginRepositorio;
            claveSecreta = configuration.GetValue<string>("ApiSettings:Secreta");

        }



        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var respuesta = await _loginRepositorio.EjecutarSpLogin(login.usuario, login.contrasenaHash);

            if (respuesta != null && respuesta.Tables.Count > 0)
            {


                var usuario = respuesta.Tables[0].AsEnumerable().Select(row => new
                {

                    usuarioID = Convert.ToInt32(row["usuarioID"].ToString()),
                    usuario = row["usuario"].ToString(),
                    nombreCompleto = row["nombreCompleto"].ToString(),
                    rol = row["rol"].ToString(),
                }).ToList();


                var manejadorToken = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(claveSecreta);

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {

                        new Claim(ClaimTypes.Name, usuario[0].usuario),
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = manejadorToken.CreateToken(tokenDescription);

                var respuestaFinal = new
                {
                    Token = manejadorToken.WriteToken(token),
                    usuario = usuario
                };
                return Ok(respuestaFinal);

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
