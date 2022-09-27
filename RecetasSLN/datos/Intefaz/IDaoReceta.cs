using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.Interfaz
{
     interface IDaoReceta
    {
        int ObtenerProximo();
        List<TipoReceta> ObtenerTipos();
        List<Ingrediente> ObtenerIngredientes();
    }
}
