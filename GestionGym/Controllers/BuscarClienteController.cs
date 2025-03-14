using System.Data;
using GestionGym.Repositosios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscarClienteController : ControllerBase
    {

        private readonly BuscarClienteRepositorio _buscarClienteRepositorio;
        public BuscarClienteController(BuscarClienteRepositorio buscarClienteRepositorio)
        {
            _buscarClienteRepositorio = buscarClienteRepositorio;
        }

        [HttpGet("buscar/{cedula}")]
        public async Task<IActionResult> ObtenerClientePorCedula(string cedula)
        {
            var respuesta = await _buscarClienteRepositorio.EjecutarSpCliente(1, cedula );

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
