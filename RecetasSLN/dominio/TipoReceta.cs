using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class TipoReceta
    {
        public int IdTipo { get; set; }
        public string NombreTipo { get; set; }

        public TipoReceta(int id,string nombre)
        {
            IdTipo = id;
           NombreTipo=nombre;
        }
        public TipoReceta()
        {
            IdTipo = 0;
            NombreTipo = string.Empty;
        }
    }
}
