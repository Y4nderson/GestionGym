using GestionGym.Modelos;
using System.Data;
using GestionGym.Repositosios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembresiaController : ControllerBase
    {

        private readonly MembresiaRepositorio _membresiaRepositorio;
        public MembresiaController(MembresiaRepositorio membresiaRepositorio)
        {
            _membresiaRepositorio = membresiaRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerMembresia()
        {

            var respuesta = await _membresiaRepositorio.EjecutarSpMembresia(90, 0, 0, 0, DateTime.Now, DateTime.Now, "", 0);


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



        [HttpGet("{membresiaID}")]
        public async Task<IActionResult> ObtenerMembresiaXID(int membresiaID)
        {

            var respuesta = await _membresiaRepositorio.EjecutarSpMembresia(91, membresiaID, 0, 0, DateTime.Now, DateTime.Now, "", 0);


            if (respuesta != null && respuesta.Tables.Count > 0 && respuesta.Tables[0].Rows.Count > 0)
            {

                var fila = respuesta.Tables[0].Rows[0];

                var membresia = new Dictionary<string, object>();

                foreach (DataColumn columna in respuesta.Tables[0].Columns)
                {
                    membresia[columna.ColumnName] = fila[columna];
                }


                return Ok(membresia);

            }
            else
            {
                return NotFound("No se encontraron datos");
            }

        }


        [HttpPost]
        public async Task<IActionResult> CrearMembresia([FromBody] Membresia membresia)
        {

            if (!ModelState.IsValid || membresia == null)
            {
                return BadRequest();
            }

            var respuesta = await _membresiaRepositorio.EjecutarSpMembresia(
               membresia.proceso,
               membresia.membresiaID,
               membresia.clienteID,
               membresia.tipoDeMembresiaID,
               membresia.fechaInicio,
               membresia.fechaVencimiento,
               membresia.estadoMembresia,
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
        public async Task<IActionResult> ActualizarMembresia([FromBody] Membresia membresia)
        {

            if (!ModelState.IsValid || membresia == null)
            {
                return BadRequest();
            }

            var respuesta = await _membresiaRepositorio.EjecutarSpMembresia(
               membresia.proceso,
               membresia.membresiaID,
               membresia.clienteID,
               membresia.tipoDeMembresiaID,
               membresia.fechaInicio,
               membresia.fechaVencimiento,
               membresia.estadoMembresia,
               membresia.estado


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

        [HttpDelete("{membresiaID:int}")]
        public async Task<IActionResult> EliminarMembresia(int membresiaID)
        {

            var respuesta = await _membresiaRepositorio.EjecutarSpMembresia(

                3,
                membresiaID,
                0, 0, DateTime.Now, DateTime.Now, "", 0


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
