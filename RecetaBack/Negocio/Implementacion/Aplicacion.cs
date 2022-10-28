using RecetaBack.datos.Implementacion;
using RecetaBack.datos.Interfaz;
using RecetaBack.dominio;
using RecetaBack.Negocio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaBack.Negocio.Implementacion
{
    public class Aplicacion : IAplicacion
    {
        private IDaoReceta dao;
       
        public Aplicacion()
        {
            dao = new RecetaDao();
        }

        public List<Ingrediente> ObtenerIngredientes()
        {
            return dao.ObtenerIngredientes();
        }

        public int ObtenerProximo()
        {
            return dao.ObtenerProximo();
        }

        public List<TipoReceta>ObtenerTipos()
        {
           return dao.ObtenerTipos();
        }

        public bool Save(Receta oReceta)
        {
            return dao.Save(oReceta);
        }
    }
}
