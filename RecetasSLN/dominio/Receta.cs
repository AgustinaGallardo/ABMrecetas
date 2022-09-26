using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Receta
    {
        public int RecetaNro { get; set; }
        public string Nombre { get; set; }
        public int TipoReceta { get; set; }
        public string Cheff { get; set; }
       public List<DetalleReceta> Detalles { get; set; }

        public Receta (int recetaNro,string nombre,int tipoReceta,string cheff,List<DetalleReceta> detalles)
        {
            RecetaNro = recetaNro;
            Nombre = nombre;
            TipoReceta = tipoReceta;
            Cheff = cheff;
            Detalles = detalles;
            
        }
        public Receta()
        {
            this.RecetaNro = 0;
            this.TipoReceta= 0;
            this.TipoReceta=0;
            this.Cheff ="";
            Detalles = new List<DetalleReceta>();
        }
        
    }
}
