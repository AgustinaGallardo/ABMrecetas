using RecetaBack.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetaBack.Negocio.Interfaz
{
   public interface IAplicacion
    {
        int ObtenerProximo();

        List<TipoReceta> ObtenerTipos();
        List<Ingrediente> ObtenerIngredientes();
        bool Save(Receta oReceta);
    }
}
