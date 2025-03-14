using System.Data;
using System.Runtime.ConstrainedExecution;
using GestionGym.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GestionGym.Repositosios
{
    public class UsuarioRepositorio
    {
        private readonly AplicationsDbContext _dbcontext;
        public UsuarioRepositorio(AplicationsDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<DataSet> EjecutarSpUsuario(int proceso, int usuarioID, string usuario, string contrasenaHash, string correoElectronico, string nombreCompleto, string rol, string permisos, int estado)
        {

            var procesoParam = new SqlParameter("@PROCESO", SqlDbType.Int) { Value = proceso };
            var usuarioIDParam = new SqlParameter("@USUARIOID", SqlDbType.Int) { Value = usuarioID };
            var usuarioParam = new SqlParameter("@USUARIO", SqlDbType.VarChar, 100) { Value = usuario };
            var contrasenaHashParam = new SqlParameter("@CONTRASENAHASH", SqlDbType.VarChar, 255) { Value = contrasenaHash };
            var correoElectronicoParam = new SqlParameter("@CORREOELECTRONICO", SqlDbType.VarChar, 100) { Value = correoElectronico };
            var nombreCompletoParam = new SqlParameter("@NOMBRECOMPLETO", SqlDbType.VarChar, 100) { Value = nombreCompleto };
            var rolParam = new SqlParameter("@ROL", SqlDbType.VarChar, 50) { Value = rol };
            var permisosParam = new SqlParameter("@PERMISOS", SqlDbType.VarChar, 255) { Value = permisos };
            var estadoParam = new SqlParameter("@ESTADO", SqlDbType.Int) { Value = estado };

            var respuestaParam = new SqlParameter("@RESPUESTA", SqlDbType.VarChar, 100);
            respuestaParam.Direction = ParameterDirection.Output;
            var dataSet = new DataSet();

            using (var comand = _dbcontext.Database.GetDbConnection().CreateCommand())
            {
                comand.CommandType = CommandType.StoredProcedure;
                comand.CommandText = "SP_USUARIO";
                comand.Parameters.Add(procesoParam);
                comand.Parameters.Add(usuarioIDParam);
                comand.Parameters.Add(usuarioParam);
                comand.Parameters.Add(contrasenaHashParam);
                comand.Parameters.Add(correoElectronicoParam);
                comand.Parameters.Add(nombreCompletoParam);
                comand.Parameters.Add(rolParam);
                comand.Parameters.Add(permisosParam);
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
