using RecetasSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.Implementacion
{
    internal class Servicio
    {
        private IDaoReceta dao;
       
            public Servicio()
        {
            dao= new RecetaDao();
        }
        public int ObtenerProximo()
        {
            return dao.ObtenerProximo();
        }



    }
}
