using GestionGym.Modelos;
using System.Data;
using GestionGym.Repositosios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {


        private readonly PagoRepositorio _pagoRepositorio;
        public PagoController(PagoRepositorio pagoRepositorio)
        {
            _pagoRepositorio = pagoRepositorio;
        }



        [HttpGet]
        public async Task<IActionResult> ObtenerPago()
        {

            var respuesta = await _pagoRepositorio.EjecutarSpPago(90, 0, "", "", "", "", "", 0);


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



        [HttpGet("{pagoID}")]
        public async Task<IActionResult> ObtenerPagoXID(int pagoID)
        {

            var respuesta = await _pagoRepositorio.EjecutarSpPago(91, pagoID, "", "", "", "", "", 0);


            if (respuesta != null && respuesta.Tables.Count > 0 && respuesta.Tables[0].Rows.Count > 0)
            {

                var fila = respuesta.Tables[0].Rows[0];

                var pago = new Dictionary<string, object>();

                foreach (DataColumn columna in respuesta.Tables[0].Columns)
                {
                    pago[columna.ColumnName] = fila[columna];
                }


                return Ok(pago);

            }
            else
            {
                return NotFound("No se encontraron datos");
            }

        }


        [HttpPost]
        public async Task<IActionResult> CrearPago([FromBody] Pago pago)
        {

            if (!ModelState.IsValid || pago == null)
            {
                return BadRequest();
            }

            var respuesta = await _pagoRepositorio.EjecutarSpPago(
               pago.proceso,
               pago.pagoID,
               pago.cedula,
               pago.tipo_membresia_nombre,
               pago.metodoPago,
               pago.concepto,
               pago.usuario,
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
        public async Task<IActionResult> ActualizarPago([FromBody] Pago pago)
        {

            if (!ModelState.IsValid || pago == null)
            {
                return BadRequest();
            }

            var respuesta = await _pagoRepositorio.EjecutarSpPago(
               pago.proceso,
               pago.pagoID,
               pago.cedula,
               pago.tipo_membresia_nombre,
               pago.metodoPago,
               pago.concepto,
               pago.usuario,
               pago.estado


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

        [HttpDelete("{pagoID:int}")]
        public async Task<IActionResult> EliminarPago(int pagoID)
        {

            var respuesta = await _pagoRepositorio.EjecutarSpPago(3, pagoID, "", "", "", "", "", 0);


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
