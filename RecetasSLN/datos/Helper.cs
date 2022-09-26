using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RecetasSLN.datos
{
    internal class Helper
    {
        private static Helper instancia;
        SqlCommand cmd = new SqlCommand();
        SqlConnection cnn = new SqlConnection(Properties.Resources.recetasBD);


        public static Helper ObtenerInstancia() //SINGLETON
        {
            if (instancia == null)
                instancia = new Helper();
            return instancia;
        }

        public int ObtenerProximo(string sp_nombre, string nombreOutPut)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText=sp_nombre;
            cmd.CommandType=CommandType.StoredProcedure;
            SqlParameter OutPut = new SqlParameter();
            OutPut.ParameterName = sp_nombre;
            OutPut.Direction = ParameterDirection.Output;
            OutPut.DbType=DbType.Int32;
            cmd.Parameters.Add(OutPut);
            cmd.ExecuteNonQuery();
            return (int)OutPut.Value;

        }

    }
}
