using System.Data;
using GestionGym.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionGym.Repositosios
{
    public class ClienteRepositorio
    {

        private readonly AplicationsDbContext _dbContext;
        public ClienteRepositorio(AplicationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<DataSet> EjecutarSpCliente(int proceso, int clienteID, string nombreCompleto, string cedula, string telefono, string correoElectronico,  int estado)
        {
            var procesoParam = new SqlParameter("@PROCESO", SqlDbType.Int) { Value = proceso };
            var clienteIDParam = new SqlParameter("@CLIENTEID", SqlDbType.Int) { Value = clienteID };
            var nombreCompletoParam = new SqlParameter("@NOMBRECOMPLETO", SqlDbType.VarChar, 100) { Value = nombreCompleto };
            var cedulaParam = new SqlParameter("@CEDULA", SqlDbType.VarChar, 20) { Value = cedula };
            var telefonoParam = new SqlParameter("@TELEFONO", SqlDbType.VarChar, 20) { Value = telefono };
            var correoElectronicoParam = new SqlParameter("@CORREOELECTRONICO", SqlDbType.VarChar, 255) { Value = correoElectronico };
            var estadoParam = new SqlParameter("@ESTADO", SqlDbType.Int) { Value = estado };

            var respuestaParam = new SqlParameter("@RESPUESTA", SqlDbType.VarChar, 100);
            respuestaParam.Direction = ParameterDirection.Output;

            var dataSet = new DataSet();

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_CLIENTE";
                command.Parameters.Add(procesoParam);
                command.Parameters.Add(clienteIDParam);
                command.Parameters.Add(nombreCompletoParam);
                command.Parameters.Add(cedulaParam);
                command.Parameters.Add(telefonoParam);
                command.Parameters.Add(correoElectronicoParam);
                command.Parameters.Add(estadoParam);
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
