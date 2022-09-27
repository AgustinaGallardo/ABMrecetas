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
        public TipoReceta TipoReceta { get; set; }

        public string Cheff { get; set; }
        public List<DetalleReceta> Detalles { get; set; }

        public Receta(int recetaNro, string nombre, TipoReceta tipoReceta, string cheff, List<DetalleReceta> detalles)
        {
            RecetaNro = recetaNro;
            Nombre = nombre;
            TipoReceta = tipoReceta;
            Cheff = cheff;
            Detalles = detalles;
        }

        public Receta()
        {
            RecetaNro = 0;
            Nombre = string.Empty;
            TipoReceta = null;
            Cheff = string.Empty;
            Detalles = new List<DetalleReceta>();
        }

        public int CalcularIngredientes()
        {
            int cantidad = 0;
            foreach(DetalleReceta item in Detalles)
            {
                cantidad += item.Cantidad;               
            }
            return cantidad;
        }

        public void AgregarDetalle(DetalleReceta detalle)
        {
            Detalles.Add(detalle);

        }

    }
}
