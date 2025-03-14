using System.Data;
using GestionGym.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionGym.Repositosios
{
    public class MembresiaRepositorio
    {


        private readonly AplicationsDbContext _context;
        public MembresiaRepositorio(AplicationsDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<DataSet> EjecutarSpMembresia(int proceso, int membresiaID, int clienteID, int tipoDeMembresiaID, DateTime fechaInicio, DateTime fechaVencimiento, string estadoMembresia, int estado)
        {

            var procesoParam = new SqlParameter("@PROCESO", SqlDbType.Int) { Value = proceso };
            var membresiaIDParam = new SqlParameter("@MEMBRESIAID", SqlDbType.Int) { Value = membresiaID };
            var clienteIDParam = new SqlParameter("@CLIENTEID", SqlDbType.Int) { Value = clienteID };
            var tipoDeMembresiaIDParam = new SqlParameter("@TIPOMEMBRESIAID", SqlDbType.Int) { Value = tipoDeMembresiaID };
            var fechaInicioParam = new SqlParameter("@FECHAINICIO", SqlDbType.DateTime) { Value = fechaInicio };
            var fechaVencimientoParam = new SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime) { Value = fechaVencimiento };
            var estadoMembresiaParam = new SqlParameter("@ESTADOMEMBRESIA", SqlDbType.VarChar, 50) { Value = estadoMembresia };
            var estadoParam = new SqlParameter("@ESTADO", SqlDbType.Int) { Value = estado };

            var respuestaParam = new SqlParameter("@RESPUESTA", SqlDbType.VarChar, 100);
            respuestaParam.Direction = ParameterDirection.Output;
            var dataSet = new DataSet();

            using (var comand = _context.Database.GetDbConnection().CreateCommand())
            {
                comand.CommandType = CommandType.StoredProcedure;
                comand.CommandText = "SP_MEMBRESIA";
                comand.Parameters.Add(procesoParam);
                comand.Parameters.Add(membresiaIDParam);
                comand.Parameters.Add(clienteIDParam);
                comand.Parameters.Add(tipoDeMembresiaIDParam);
                comand.Parameters.Add(fechaInicioParam);
                comand.Parameters.Add(fechaVencimientoParam);
                comand.Parameters.Add(estadoMembresiaParam);
                comand.Parameters.Add(estadoParam);
                comand.Parameters.Add(respuestaParam);

                using (var dataAdapter = new SqlDataAdapter((SqlCommand)comand))
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
