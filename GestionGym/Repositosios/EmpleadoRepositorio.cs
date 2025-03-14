using System.Data;
using GestionGym.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionGym.Repositosios
{
    public class EmpleadoRepositorio
    {


        private readonly AplicationsDbContext _context;
        public EmpleadoRepositorio(AplicationsDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<DataSet> EjecutarSpEmpleado(int proceso, int empleadoID, string nombreCompleto, string cedula, string telefono, string cargo,string horario, float salario, int estado, string usuario)
        {
            var procesoParam = new SqlParameter("@PROCESO", SqlDbType.Int) { Value = proceso };
            var empleadoIDParam = new SqlParameter("@EMPLEADOID", SqlDbType.Int) { Value = empleadoID };
            var nombreCompletoParam = new SqlParameter("@NOMBRECOMPLETO", SqlDbType.VarChar, 100) { Value = nombreCompleto };
            var cedulaParam = new SqlParameter("@CEDULA", SqlDbType.VarChar, 100) { Value = cedula };
            var telefonoParam = new SqlParameter("@TELEFONO", SqlDbType.VarChar, 255) { Value = telefono };
            var cargoParam = new SqlParameter("@CARGO", SqlDbType.VarChar, 100) { Value = cargo };
            var horarioParam = new SqlParameter("@HORARIO", SqlDbType.VarChar, 50) { Value = horario };
            var salarioParam = new SqlParameter("@SALARIO", SqlDbType.Float) { Value = salario };
            var estadoParam = new SqlParameter("@ESTADO", SqlDbType.Int) { Value = estado };
            var usuarioParam = new SqlParameter("@USUARIO", SqlDbType.VarChar, 100) { Value = usuario };


            var respuestaParam = new SqlParameter("@RESPUESTA", SqlDbType.VarChar, 100);
            respuestaParam.Direction = ParameterDirection.Output;
            var dataSet = new DataSet();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_EMPLEADO";
                command.Parameters.Add(procesoParam);
                command.Parameters.Add(empleadoIDParam);
                command.Parameters.Add(nombreCompletoParam);
                command.Parameters.Add(cedulaParam);
                command.Parameters.Add(telefonoParam);
                command.Parameters.Add(cargoParam);
                command.Parameters.Add(horarioParam);
                command.Parameters.Add(salarioParam);
                command.Parameters.Add(estadoParam);
                command.Parameters.Add(usuarioParam);
                command.Parameters.Add(respuestaParam);

                using (var dataAdapter = new SqlDataAdapter((SqlCommand)command))
                {
                    await Task.Run(() =>
                    {
                        dataAdapter.Fill(dataSet);
                    });
                }
                return dataSet;
            }
        }

    }
}
