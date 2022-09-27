using RecetasSLN.dominio;
using RecetasSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.Implementacion
{
     class Servicio : iServicio
    {
        private IDaoReceta dao;
       
        public Servicio()
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
    }
}
