using System.Data;
using GestionGym.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionGym.Repositosios
{
    public class PagoRepositorio
    {

        private readonly AplicationsDbContext _context;
        public PagoRepositorio(AplicationsDbContext context)
        {
            _context = context;
        }


        public async Task<DataSet> EjecutarSpPago(int proceso, int pago, string cedula, string tipoMembresia,
            string metodoDePago, string concepto,string usuario,int estado)
        {
            var dataSet = new DataSet();
            var procesoParam = new SqlParameter("@PROCESO", SqlDbType.Int) {Value = proceso };
            var pagoParam = new SqlParameter("@PAGOID", SqlDbType.Int) {Value = pago };
            var cedulaParam = new SqlParameter("@CEDULA", SqlDbType.VarChar,50) {Value = cedula };
            var tipoMembresiaParam = new SqlParameter("@TIPO_MEMBRESIA_NOMBRE", SqlDbType.VarChar,100) {Value = tipoMembresia };
            var metodoDePagoParam = new SqlParameter("@METODOPAGO", SqlDbType.VarChar,50) {Value = metodoDePago };
            var conceptoParam = new SqlParameter("@CONCEPTO", SqlDbType.VarChar, 255) {Value = concepto };
            var usuarioParam = new SqlParameter("@USUARIO", SqlDbType.VarChar,100) {Value = usuario };
            var estadoParam = new SqlParameter("@ESTADO", SqlDbType.Int) {Value = estado };
            var respuestaParam = new SqlParameter("@RESPUESTA", SqlDbType.VarChar, 100);
            respuestaParam.Direction = ParameterDirection.Output;

            using (var comand = _context.Database.GetDbConnection().CreateCommand())
            {
                comand.CommandType = CommandType.StoredProcedure;

                comand.CommandText = "SP_PAGOS";

                comand.Parameters.Add(procesoParam);
                comand.Parameters.Add(pagoParam);
                comand.Parameters.Add(cedulaParam);
                comand.Parameters.Add(tipoMembresiaParam);
                comand.Parameters.Add(metodoDePagoParam);
                comand.Parameters.Add(conceptoParam);
                comand.Parameters.Add(usuarioParam);
                comand.Parameters.Add(estadoParam);
                comand.Parameters.Add(respuestaParam);

                using(var dataAdapter = new SqlDataAdapter((SqlCommand)comand))
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
