using GestionGym.Modelos;
using System.Data;
using GestionGym.Repositosios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ClienteRepositorio _clienteRepositorio;
        public ClienteController(ClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCliente()
        {

            var respuesta = await _clienteRepositorio.EjecutarSpCliente(90,0,"","","","",0);


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
        [HttpGet("activos")]
        public async Task<IActionResult> ObtenerClienteActivo()
        {

            var respuesta = await _clienteRepositorio.EjecutarSpCliente(91, 0, "", "", "", "", 0);


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
        [HttpGet("inactivos")]
        public async Task<IActionResult> ObtenerClienteInactivo()
        {

            var respuesta = await _clienteRepositorio.EjecutarSpCliente(92, 0, "", "", "", "", 0);


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

        [HttpGet("porVencer")]
        public async Task<IActionResult> ObtenerClientePorVencer()
        {

            var respuesta = await _clienteRepositorio.EjecutarSpCliente(93, 0, "", "", "", "", 0);


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

        [HttpGet("vencidos")]
        public async Task<IActionResult> ObtenerClienteVencidos()
        {

            var respuesta = await _clienteRepositorio.EjecutarSpCliente(97, 0, "", "", "", "", 0);


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

        [HttpGet("cantidadTotalClientes")]
        public async Task<IActionResult> ObtenerClienteCantidad()
        {

            var respuesta = await _clienteRepositorio.EjecutarSpCliente(94, 0, "", "", "", "", 0);


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



        [HttpGet("{clienteID}")]
        public async Task<IActionResult> ObtenerClienteXID(int clienteID)
        {

            var respuesta = await _clienteRepositorio.EjecutarSpCliente(4, clienteID, "", "", "", "", 0);


            if (respuesta != null && respuesta.Tables.Count > 0 && respuesta.Tables[0].Rows.Count > 0)
            {

                var fila = respuesta.Tables[0].Rows[0];

                var cliente = new Dictionary<string, object>();

                foreach (DataColumn columna in respuesta.Tables[0].Columns)
                {
                    cliente[columna.ColumnName] = fila[columna];
                }


                return Ok(cliente);

            }
            else
            {
                return NotFound("No se encontraron datos");
            }

        }


        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarClientes([FromQuery] string filtro)
        {
            var respuesta = await _clienteRepositorio.EjecutarSpCliente(95, 0, filtro, filtro, filtro, "", 0);

            if (respuesta != null && respuesta.Tables.Count > 0 && respuesta.Tables[0].Rows.Count > 0)
            {
                var clientes = new List<Dictionary<string, object>>();

                foreach (DataRow fila in respuesta.Tables[0].Rows)
                {
                    var cliente = new Dictionary<string, object>();

                    foreach (DataColumn columna in respuesta.Tables[0].Columns)
                    {
                        cliente[columna.ColumnName] = fila[columna];
                    }

                    clientes.Add(cliente);
                }

                return Ok(clientes);
            }
            else
            {
                return NotFound("No se encontraron clientes.");
            }
        }




        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] Cliente cliente)
        {

            if (!ModelState.IsValid || cliente == null)
            {
                return BadRequest();
            }

            var respuesta = await _clienteRepositorio.EjecutarSpCliente(
               cliente.proceso,
               cliente.clienteID,
               cliente.nombreCompleto,
               cliente.cedula,
               cliente.telefono,
               cliente.correo,
                0




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
        public async Task<IActionResult> ActualizarCliente([FromBody] Cliente cliente)
        {

            if (!ModelState.IsValid || cliente == null)
            {
                return BadRequest();
            }

            var respuesta = await _clienteRepositorio.EjecutarSpCliente(
               cliente.proceso,
               cliente.clienteID,
               cliente.nombreCompleto,
               cliente.cedula,
               cliente.telefono,
               cliente.correo,
                cliente.estado




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

        [HttpDelete("{clienteID:int}")]
        public async Task<IActionResult> EliminarCliente(int clienteID)
        {

            var respuesta = await _clienteRepositorio.EjecutarSpCliente(

                3,
                clienteID,
                "", "", "", "", 0


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

        [HttpGet("buscar/{nombre}")]
        public async Task<IActionResult> ObtenerClientePorNombre(string nombre)
        {
            var respuesta = await _clienteRepositorio.EjecutarSpCliente(95, 0, nombre, "", "", "", 0);

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

    }
}
