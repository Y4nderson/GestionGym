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

            var respuesta = await _pagoRepositorio.EjecutarSpPago(90, 0, "", "", "", "", "", DateTime.Now, DateTime.Now, 0);


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
        [HttpGet("ObtenerTiposMembresia")]
        public async Task<IActionResult> ObtenerTiposMembresia()
        {

            var respuesta = await _pagoRepositorio.EjecutarSpPago(101, 0, "", "", "", "", "", DateTime.Now, DateTime.Now, 0);


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

        [HttpGet("ObtenerTiposUsuario")]
        public async Task<IActionResult> ObtenerTiposUsuario()
        {

            var respuesta = await _pagoRepositorio.EjecutarSpPago(102, 0, "", "", "", "", "", DateTime.Now, DateTime.Now, 0);


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


        [HttpGet("ObtenerPagosAntiguos")]
        public async Task<IActionResult> ObtenerPagoAntiguos()
        {

            var respuesta = await _pagoRepositorio.EjecutarSpPago(92, 0, "", "", "", "", "", DateTime.Now, DateTime.Now, 0);


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


        [HttpGet("ObtenerPagosCantidad")]
        public async Task<IActionResult> ObtenerPagosCantidad()
        {

            var respuesta = await _pagoRepositorio.EjecutarSpPago(98, 0, "", "", "", "", "",DateTime.Now,DateTime.Now, 0);


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

        [HttpGet("ObtenerPagosRangoFechas")]
        public async Task<IActionResult> ObtenerPagosRangoFechas([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var respuesta = await _pagoRepositorio.EjecutarSpPago(97, 0, "", "", "", "", "", fechaInicio, fechaFin, 0);

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



        [HttpGet("ObtenerNombreMembresia")]
        public async Task<IActionResult> ObtenerPagoNombreMembresia(string nombreMembresia)
        {

            var respuesta = await _pagoRepositorio.EjecutarSpPago(93, 0, "", nombreMembresia, "", "", "", DateTime.Now, DateTime.Now, 0);


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


        [HttpGet("ObtenerPagosPorCliente")]
        public async Task<IActionResult> ObtenerPagosPorCliente(string nombreCliente)
        {
            var respuesta = await _pagoRepositorio.EjecutarSpPago(94, 0, nombreCliente, "", "", "", "", DateTime.Now, DateTime.Now, 1);

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
                return NotFound("No se encontraron pagos para el cliente especificado.");
            }
        }

        [HttpGet("ObtenerPagosUltimoCliente")]
        public async Task<IActionResult> ObtenerPagosUltimoCliente(string cedula)
        {
            var respuesta = await _pagoRepositorio.EjecutarSpPago(100, 0, cedula, "", "", "", "", DateTime.Now, DateTime.Now,1);

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
                return NotFound("No se encontraron pagos para el cliente especificado.");
            }
        }




        [HttpGet("{pagoID}")]
        public async Task<IActionResult> ObtenerPagoXID(int pagoID)
        {

            var respuesta = await _pagoRepositorio.EjecutarSpPago(91, pagoID, "", "", "", "", "", DateTime.Now, DateTime.Now, 0);


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

            bool existeCliente = await _pagoRepositorio.ClienteExiste(pago.cedula);
            if (!existeCliente)
            {
                return NotFound("No se encontró un cliente con esa cédula.");
            }

            var respuesta = await _pagoRepositorio.EjecutarSpPago(
               pago.proceso,
               pago.pagoID,
               pago.cedula,
               pago.tipo_membresia_nombre,
               pago.metodoPago,
               pago.concepto,
               pago.usuario,
               pago.fechaInicio,
               pago.fechaFin,
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



        [HttpDelete("{pagoID:int}")]
        public async Task<IActionResult> EliminarPago(int pagoID)
        {

            var respuesta = await _pagoRepositorio.EjecutarSpPago(3, pagoID, "", "", "", "", "", DateTime.Now, DateTime.Now, 0);


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
