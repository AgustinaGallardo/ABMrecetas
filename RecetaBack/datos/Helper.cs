using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetaBack.dominio;

namespace RecetaBack.datos
{
    internal class Helper
    {
        private static Helper instancia;
        private string cnnString;

        private Helper()
        {
            cnnString = @"Data Source=DESKTOP-DBB4CIB\SQLEXPRESS;Initial Catalog=recetas_db;Integrated Security=True";
        }
        public static Helper ObtenerInstancia() //SINGLETON
        {
            if (instancia == null)
                instancia = new Helper();
            return instancia;
        }
        public int ObtenerProximo(string sp_nombre, string nombreOutPut)
        {   
            
            SqlConnection cnn = new SqlConnection(cnnString);
            cnn.Open();
            SqlCommand cmdProx = new SqlCommand();            
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
        public DataTable CargarCombo(string sp_nombre)
        {
            SqlConnection cnn = new SqlConnection(cnnString);
            DataTable tabla = new DataTable();
            SqlCommand cmdCombo = new SqlCommand();
            cnn.Open();            
            cmdCombo.Connection = cnn;
            cmdCombo.CommandText=sp_nombre;
            cmdCombo.CommandType=CommandType.StoredProcedure;

            

            tabla.Load(cmdCombo.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public bool ConfirmarReceta(Receta rec,string sp_maestro, string sp_detalle) 
        {
            bool ok = true;
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlTransaction t = null;

            try
            {
                
                SqlCommand cmdMaestro = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();

                cmdMaestro.Connection = cnn;
                cmdMaestro.Transaction =t;
                cmdMaestro.CommandText= sp_maestro;
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
                    cmdDetalle.CommandText= sp_detalle;
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
