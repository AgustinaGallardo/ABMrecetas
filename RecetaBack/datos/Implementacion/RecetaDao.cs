using RecetaBack.datos;
using RecetaBack.datos.Interfaz;
using RecetaBack.dominio;
using RecetaBack.Negocio.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaBack.datos.Implementacion
{
      class RecetaDao : IDaoReceta
      {
        
        public int ObtenerProximo()
        {           
            string sp_nombre = "sp_ObtenerProximo";
            string nombreOutPut = "@Next";

            return Helper.ObtenerInstancia().ObtenerProximo(sp_nombre,nombreOutPut);
        }

        public List<TipoReceta> ObtenerTipos()
        {
            List<TipoReceta> lstTipoReceta = new List<TipoReceta>();
            string sp_nombre = "sp_ConsultarTipos";
            DataTable tb = Helper.ObtenerInstancia().CargarCombo(sp_nombre);
            foreach (DataRow dr in tb.Rows )
  //convertir lo que viene como registro de sql a objeto -- MAPEAR UN REGISTRO A OBJ DE DOMINIO
            {
                int id = int.Parse(dr["tipo_receta"].ToString());
                string tipo = dr["tipoNombre"].ToString();
                TipoReceta Treceta = new TipoReceta(id,tipo);
                lstTipoReceta.Add(Treceta);
            }
            return lstTipoReceta;
        }


        public List<Ingrediente> ObtenerIngredientes()
        {
            List<Ingrediente> lstIngrediente = new List<Ingrediente>();
            string sp_nombre = "SP_CONSULTAR_INGREDIENTES";
            DataTable tb = Helper.ObtenerInstancia().CargarCombo(sp_nombre);

            foreach (DataRow dr in tb.Rows)           
            {             
                int id = int.Parse(dr["id_ingrediente"].ToString()); //tal cual como se llama en SQL
                string tipo = dr["n_ingrediente"].ToString();
                Ingrediente aux = new Ingrediente(id,tipo);  
            
                lstIngrediente.Add(aux);
            }
            return lstIngrediente;
        }

        public bool Save(Receta oReceta)
        {
            string sp_maestro = "sp_insertar_receta";
            string sp_detalle = "sp_insertar_detalles";
            return Helper.ObtenerInstancia().ConfirmarReceta(oReceta,sp_maestro, sp_detalle);
        }
    }
}
