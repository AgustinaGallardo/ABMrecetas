using RecetasSLN.datos;
using RecetasSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.Implementacion
{
    internal class RecetaDao : IDaoReceta
    {
        public int ObtenerProximo()
        {           
            string sp_nombre = "sp_ObtenerProximo";
            string nombreOutPut = "@Next";
            return Helper.ObtenerInstancia().ObtenerProximo(sp_nombre,nombreOutPut);
    }
    }
}
