using System.Data;
using GestionGym.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionGym.Repositosios
{
    public class AsistenciaRepositorio
    {
        private readonly AplicationsDbContext _context;
        public AsistenciaRepositorio(AplicationsDbContext context)
        {
            _context = context;
        }

        public async Task<DataSet> EjecutarSpAsistencia(int proceso, int asistenciaID, int clienteID, DateTime fechaEntrada,string nombre)
        {
            var procesoParam = new SqlParameter("@PROCESO", SqlDbType.Int) { Value = proceso };
            var asistenciaIDParam = new SqlParameter("@ASISTENCIAID", SqlDbType.Int) { Value = asistenciaID };
            var clienteIDParam = new SqlParameter("@CLIENTEID", SqlDbType.Int) { Value = clienteID };
            var fechaEntradaParam = new SqlParameter("@FECHAENTRADA", SqlDbType.DateTime) { Value = fechaEntrada };
            var nombreParam = new SqlParameter("@NOMBRE", SqlDbType.VarChar,100) { Value = nombre };


            var respuestaParam = new SqlParameter("@RESPUESTA", SqlDbType.VarChar, 100);
            respuestaParam.Direction = ParameterDirection.Output;
            var dataSet = new DataSet();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_ASISTENCIA";
                command.Parameters.Add(procesoParam);

                command.Parameters.Add(asistenciaIDParam);
                command.Parameters.Add(clienteIDParam);
                command.Parameters.Add(fechaEntradaParam);
                command.Parameters.Add(nombreParam);

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
