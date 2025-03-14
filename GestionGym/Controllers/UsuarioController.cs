using System.Data;
using GestionGym.Modelos;
using GestionGym.Repositosios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuario()
        {

            var respuesta = await _usuarioRepositorio.EjecutarSpUsuario(90,0,"","","","","","",0);


            if (respuesta != null && respuesta.Tables.Count > 0)
            {


                var ListaResultado = new List<Dictionary<string, object>>();

                foreach (DataRow Fila in respuesta.Tables[0].Rows)
                {

                    var filaDatos = new Dictionary<string, object>();


                    foreach (DataColumn Columna in respuesta.Tables[0].Columns)
                    {

                        filaDatos[Columna.ColumnName] = Fila[Columna];

                    }
                    ListaResultado.Add(filaDatos);
                }
                return Ok(ListaResultado);
            }
            else
            {
                return NotFound("No se encontraron datos");
            }

        }



        [HttpGet("{usuarioID}")]
        public async Task<IActionResult> ObtenerUsuarioXID(int usuarioID)
        {

            var respuesta = await _usuarioRepositorio.EjecutarSpUsuario(91, usuarioID, "", "", "", "", "", "", 0);


            if (respuesta != null && respuesta.Tables.Count > 0 && respuesta.Tables[0].Rows.Count > 0)
            {

                var fila = respuesta.Tables[0].Rows[0];

                var usuario = new Dictionary<string, object>();

                foreach (DataColumn columna in respuesta.Tables[0].Columns)
                {
                    usuario[columna.ColumnName] = fila[columna];
                }


                return Ok(usuario);

            }
            else
            {
                return NotFound("No se encontraron datos");
            }

        }


        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario usuario)
        {

            if (!ModelState.IsValid || usuario == null)
            {
                return BadRequest();
            }

            var respuesta = await _usuarioRepositorio.EjecutarSpUsuario(
               usuario.proceso,
               usuario.usuarioID,
               usuario.usuario,
               usuario.contrasenahash,
               usuario.correoElectronico,
               usuario.nombreCompleto,
               usuario.rol,
               usuario.permisos,
               1


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



        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario([FromBody] Usuario usuario)
        {

            if (!ModelState.IsValid || usuario == null)
            {
                return BadRequest();
            }

            var respuesta = await _usuarioRepositorio.EjecutarSpUsuario(
               usuario.proceso,
               usuario.usuarioID,
               usuario.usuario,
               usuario.contrasenahash,
               usuario.correoElectronico,
               usuario.nombreCompleto,
               usuario.rol,
               usuario.permisos,
               usuario.estado


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

        [HttpDelete("{usuarioID:int}")]
        public async Task<IActionResult> EliminarUsuario(int usuarioID)
        {

            var respuesta = await _usuarioRepositorio.EjecutarSpUsuario(

                3,
                usuarioID,
                "", "", "", "", "", "", 0


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
