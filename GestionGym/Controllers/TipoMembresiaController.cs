using GestionGym.Modelos;
using System.Data;
using GestionGym.Repositosios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMembresiaController : ControllerBase
    {

        private readonly TipoMembresiaRepositorio _tipoMembresiaRepositorio;
        public TipoMembresiaController(TipoMembresiaRepositorio tipoMembresiaRepositorio)
        {
            _tipoMembresiaRepositorio = tipoMembresiaRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTipoMembresia()
        {

            var respuesta = await _tipoMembresiaRepositorio.EjecutarSpTipoMembresia(90, 0, "", 0, 0, 0);


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



        [HttpGet("{tipoDeMembresiaID}")]
        public async Task<IActionResult> ObtenerTipoMembresiaXID(int tipoDeMembresiaID)
        {

            var respuesta = await _tipoMembresiaRepositorio.EjecutarSpTipoMembresia(91, tipoDeMembresiaID, "", 0, 0, 0);


            if (respuesta != null && respuesta.Tables.Count > 0 && respuesta.Tables[0].Rows.Count > 0)
            {

                var fila = respuesta.Tables[0].Rows[0];

                var tipoMebresia = new Dictionary<string, object>();

                foreach (DataColumn columna in respuesta.Tables[0].Columns)
                {
                    tipoMebresia[columna.ColumnName] = fila[columna];
                }


                return Ok(tipoMebresia);

            }
            else
            {
                return NotFound("No se encontraron datos");
            }

        }


        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] TipoMembresia tipoMembresia)
        {

            if (!ModelState.IsValid || tipoMembresia == null)
            {
                return BadRequest();
            }

            var respuesta = await _tipoMembresiaRepositorio.EjecutarSpTipoMembresia(
               tipoMembresia.proceso,
               tipoMembresia.tipoDeMembresiaID,
               tipoMembresia.nombre,
               tipoMembresia.precio,
               tipoMembresia.duracion,
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
        public async Task<IActionResult> ActualizarTipoMembresia([FromBody] TipoMembresia tipoMembresia)
        {

            if (!ModelState.IsValid || tipoMembresia == null)
            {
                return BadRequest();
            }

            var respuesta = await _tipoMembresiaRepositorio.EjecutarSpTipoMembresia(
               tipoMembresia.proceso,
               tipoMembresia.tipoDeMembresiaID,
               tipoMembresia.nombre,
               tipoMembresia.precio,
               tipoMembresia.duracion,
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

        [HttpDelete("{tipoDeMembresiaID:int}")]
        public async Task<IActionResult> EliminarUsuario(int tipoDeMembresiaID)
        {

            var respuesta = await _tipoMembresiaRepositorio.EjecutarSpTipoMembresia(

                3,
                tipoDeMembresiaID,
                "", 0, 0, 0


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
