using System.Data;
using GestionGym.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionGym.Repositosios
{

    public class TipoMembresiaRepositorio
    {
        private readonly AplicationsDbContext _dbcontext;
        public TipoMembresiaRepositorio(AplicationsDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<DataSet> EjecutarSpTipoMembresia(int proceso, int tipoDeMembresiaID, string nombre, 
            float precio, int duracion, int estado)
        {

            var procesoParam = new SqlParameter("@PROCESO", SqlDbType.Int) { Value = proceso };
            var tipoDeMembresiaIDParam = new SqlParameter("@TIPOMEMBRESIAID", SqlDbType.Int) { Value = tipoDeMembresiaID };
            var nombreParam = new SqlParameter("@NOMBRE", SqlDbType.VarChar, 100) { Value = nombre };
            var precioParam = new SqlParameter("@PRECIO", SqlDbType.Float) { Value = precio };
            var duracionParam = new SqlParameter("@DURACION", SqlDbType.Int) { Value = duracion };
            var estadoParam = new SqlParameter("@ESTADO", SqlDbType.Int) { Value = estado };

            var respuestaParam = new SqlParameter("@RESPUESTA", SqlDbType.VarChar, 100);
            respuestaParam.Direction = ParameterDirection.Output;
            var dataSet = new DataSet();

            using (var comand = _dbcontext.Database.GetDbConnection().CreateCommand())
            {
                comand.CommandType = CommandType.StoredProcedure;
                comand.CommandText = "SP_TIPOMEMBRESIA";
                comand.Parameters.Add(procesoParam);
                comand.Parameters.Add(tipoDeMembresiaIDParam);
                comand.Parameters.Add(nombreParam);
                comand.Parameters.Add(precioParam);
                comand.Parameters.Add(duracionParam);
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
