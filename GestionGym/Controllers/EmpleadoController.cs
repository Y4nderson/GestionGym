using GestionGym.Modelos;
using System.Data;
using GestionGym.Repositosios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GestionGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {


        private readonly EmpleadoRepositorio _empleadoRepositorio;
        public EmpleadoController(EmpleadoRepositorio empleadoRepositorio)
        {
            _empleadoRepositorio = empleadoRepositorio;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ObtenerEmpleado()
        {

            var respuesta = await _empleadoRepositorio.EjecutarSpEmpleado(90, 0, "", "", "", "", "",0, 0,"");


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



        [HttpGet("{empleadoID}")]
        public async Task<IActionResult> ObtenerEmpleadoXID(int empleadoID)
        {

            var respuesta = await _empleadoRepositorio.EjecutarSpEmpleado(91, empleadoID, "", "", "", "", "", 0, 0, "");


            if (respuesta != null && respuesta.Tables.Count > 0 && respuesta.Tables[0].Rows.Count > 0)
            {

                var fila = respuesta.Tables[0].Rows[0];

                var empleado = new Dictionary<string, object>();

                foreach (DataColumn columna in respuesta.Tables[0].Columns)
                {
                    empleado[columna.ColumnName] = fila[columna];
                }


                return Ok(empleado);

            }
            else
            {
                return NotFound("No se encontraron datos");
            }

        }


        [HttpPost]
        public async Task<IActionResult> CrearEmpleado([FromBody] Empleado empleado)
        {

            if (!ModelState.IsValid || empleado == null)
            {
                return BadRequest();
            }

            var respuesta = await _empleadoRepositorio.EjecutarSpEmpleado(
               empleado.proceso,
               empleado.empleadoID,
               empleado.nombreCompleto,
               empleado.cedula,
               empleado.telefono,
               empleado.cargo,
               empleado.horarioDeTrabajo,
               empleado.salario,
               1,
               empleado.usuario


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
        public async Task<IActionResult> ActualizarEmpleado([FromBody] Empleado empleado)
        {

            if (!ModelState.IsValid || empleado == null)
            {
                return BadRequest();
            }

            var respuesta = await _empleadoRepositorio.EjecutarSpEmpleado(
               empleado.proceso,
               empleado.empleadoID,
               empleado.nombreCompleto,
               empleado.cedula,
               empleado.telefono,
               empleado.cargo,
               empleado.horarioDeTrabajo,
               empleado.salario,
               empleado.estado,
               empleado.usuario


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

        [HttpDelete("{empleadoID:int}")]
        public async Task<IActionResult> EliminarUsuario(int empleadoID)
        {

            var respuesta = await _empleadoRepositorio.EjecutarSpEmpleado(3, empleadoID, "", "", "", "", "", 0, 0, "");

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
