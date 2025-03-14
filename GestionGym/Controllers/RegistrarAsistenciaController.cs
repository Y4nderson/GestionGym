using GestionGym.Modelos;
using GestionGym.Repositosios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarAsistenciaController : ControllerBase
    {

        private readonly RegistrarAsistenciaRepositorio _registrarAsistenciaRepositorio;
        public RegistrarAsistenciaController(RegistrarAsistenciaRepositorio registrarAsistenciaRepositorio)
        {
            _registrarAsistenciaRepositorio = registrarAsistenciaRepositorio;
        }



        [HttpPost]
        public async Task<IActionResult> RegistrarAsistencia([FromBody] ClienteRegister cliente)
        {

            if (!ModelState.IsValid || cliente == null)
            {
                return BadRequest();
            }

            var respuesta = await _registrarAsistenciaRepositorio.EjecutarSpCliente(
               cliente.proceso,
               cliente.cedula





                );

            if (respuesta != null && respuesta.HasErrors == false)
            {
                return Ok();

            }
            else
            {
                return StatusCode(500, "Error del servidor ");
            }

        }
    }
}
