using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetasSLN.dominio;

namespace RecetasSLN.datos
{
    internal class Helper
    {
        private static Helper instancia;       
        SqlConnection cnn = new SqlConnection(Properties.Resources.recetasBD);

        public static Helper ObtenerInstancia() //SINGLETON
        {
            if (instancia == null)
                instancia = new Helper();
            return instancia;
        }
        public int ObtenerProximo(string sp_nombre, string nombreOutPut)
        {
            SqlCommand cmdProx = new SqlCommand();
            cnn.Open();
            cmdProx.Connection = cnn;
            cmdProx.CommandText=sp_nombre;
            cmdProx.CommandType=CommandType.StoredProcedure;
            SqlParameter OutPut = new SqlParameter();
            OutPut.ParameterName = nombreOutPut;
            OutPut.Direction = ParameterDirection.Output;
            OutPut.DbType=DbType.Int32;
            cmdProx.Parameters.Add(OutPut);
            cmdProx.ExecuteNonQuery();
            cnn.Close();
            return (int)OutPut.Value;
        }
        public DataTable CargarCombo(string sp_nombre,List<Parametro>values)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmdCombo = new SqlCommand();
            cnn.Open();            
            cmdCombo.Connection = cnn;
            cmdCombo.CommandText=sp_nombre;
            cmdCombo.CommandType=CommandType.StoredProcedure;

            if (values != null)
            {
                foreach (Parametro oParametro in values)
                {
                    cmdCombo.Parameters.AddWithValue(oParametro.Clave, oParametro.Valor);
                }
            }

            tabla.Load(cmdCombo.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public bool ConfirmarReceta(Receta rec) 
        {
            bool ok = true;

            SqlTransaction t = null;

            try
            {
                SqlCommand cmdMaestro = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();

                cmdMaestro.Connection = cnn;
                cmdMaestro.Transaction =t;
                cmdMaestro.CommandText= "SP_INSERTAR_RECETA";
                cmdMaestro.CommandType=CommandType.StoredProcedure;

                
                cmdMaestro.Parameters.AddWithValue("@nombre", rec.Nombre);
                cmdMaestro.Parameters.AddWithValue("@cheff", rec.Cheff);
                cmdMaestro.Parameters.AddWithValue("@tipo_receta", rec.TipoReceta.IdTipo);

                SqlParameter OutPut = new SqlParameter();
                OutPut.ParameterName = "@id_receta";
                OutPut.DbType=DbType.Int32;
                OutPut.Direction=ParameterDirection.Output;

                cmdMaestro.Parameters.Add(OutPut);

                cmdMaestro.ExecuteNonQuery();

                int RecetaNro = (int)OutPut.Value;


                foreach (DetalleReceta item in rec.Detalles)
                {
                    SqlCommand cmdDetalle = new SqlCommand();

                    cmdDetalle.Connection= cnn;
                    cmdDetalle.Transaction= t;
                    cmdDetalle.CommandText= "SP_INSERTAR_DETALLES";
                    cmdDetalle.CommandType= CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@id_receta", RecetaNro);
                    cmdDetalle.Parameters.AddWithValue("@id_ingrediente", item.Ingrediente.IngredienteId);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);

                    cmdDetalle.ExecuteNonQuery();

                    
                }
                t.Commit();
            }
            catch (Exception )
            {
                if (t != null)
                {
                    t.Rollback();
                    ok=false;
                }
            }
            finally
            {
                if (cnn !=null && cnn.State == ConnectionState.Open)
                    cnn.Close();

            }

            return ok;         
        }





    }
}
