using System.Data;
using GestionGym.Repositosios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private readonly AsistenciaRepositorio _asistenciaRepositorio;
        public AsistenciaController(AsistenciaRepositorio asistenciaRepositorio)
        {
            _asistenciaRepositorio = asistenciaRepositorio;
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerAsiatencia()
        {

            var respuesta = await _asistenciaRepositorio.EjecutarSpAsistencia(90, 0, 0, DateTime.Now);


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
