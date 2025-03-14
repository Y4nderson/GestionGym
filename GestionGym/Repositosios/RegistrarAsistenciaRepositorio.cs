using System.Data;
using GestionGym.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionGym.Repositosios
{
    public class RegistrarAsistenciaRepositorio
    {

        private readonly AplicationsDbContext _context;
        public RegistrarAsistenciaRepositorio(AplicationsDbContext context)
        {
            _context = context;  
        }


        public async Task<DataSet> EjecutarSpCliente(int proceso, string cedula)
        {
            var procesoParam = new SqlParameter("@PROCESO", SqlDbType.Int) { Value = proceso };
            var cedulaParam = new SqlParameter("@CEDULA", SqlDbType.VarChar, 20) { Value = cedula };
            var respuestaParam = new SqlParameter("@RESPUESTA", SqlDbType.VarChar, 100);
            respuestaParam.Direction = ParameterDirection.Output;
            var dataSet = new DataSet();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RegistrarAsistencia";
                command.Parameters.Add(procesoParam);

                command.Parameters.Add(cedulaParam);

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
