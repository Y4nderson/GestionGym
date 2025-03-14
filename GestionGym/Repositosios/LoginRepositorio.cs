using System;
using System.Data;
using GestionGym.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionGym.Repositosios
{
    public class LoginRepositorio
    {

        private readonly AplicationsDbContext _context;
        public LoginRepositorio(AplicationsDbContext context)
        {
            _context = context;
        }



        public async Task<DataSet> EjecutarSpLogin(string nombre, string clave)
        {

            var usuarioParam = new SqlParameter("@USUARIO", SqlDbType.VarChar, 50) { Value = nombre };
            var claveParam = new SqlParameter("@CONTRASENA", SqlDbType.VarChar, 255) { Value = clave };

            var respuestaParam = new SqlParameter("@RESPUESTA", SqlDbType.VarChar, 100);
            respuestaParam.Direction = ParameterDirection.Output;


            var dataSet = new DataSet();


            using (var comand = _context.Database.GetDbConnection().CreateCommand())
            {
                comand.CommandType = CommandType.StoredProcedure;
                comand.CommandText = "SP_VALIDARLOGIN";

                comand.Parameters.Add(usuarioParam);
                comand.Parameters.Add(claveParam);
                comand.Parameters.Add(respuestaParam);


                using (var dataAdapter = new SqlDataAdapter((SqlCommand)comand))
                {

                    await Task.Run(() =>
                    {

                        dataAdapter.Fill(dataSet);

                    });
                    return dataSet;
                }

            }

        }
    }
}
