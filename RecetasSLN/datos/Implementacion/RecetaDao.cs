using RecetasSLN.datos;
using RecetasSLN.dominio;
using RecetasSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.Implementacion
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
            DataTable tb = Helper.ObtenerInstancia().CargarCombo(sp_nombre,null);
            foreach (DataRow dr in tb.Rows )
        //convertir lo que viene como registro de sql a objeto --MAPEAR UN REGISTRO A OBJ DE DOMINIO
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
            DataTable tb = Helper.ObtenerInstancia().CargarCombo(sp_nombre, null);

            foreach (DataRow dr in tb.Rows)           
            {             
                int id = int.Parse(dr["id_ingrediente"].ToString());
                string tipo = dr["n_ingrediente"].ToString();
                Ingrediente aux = new Ingrediente(id,tipo);  
            
                lstIngrediente.Add(aux);
            }
            return lstIngrediente;
        }
    }
}
