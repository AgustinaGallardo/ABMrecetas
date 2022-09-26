using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Ingrediente
    {
        public int IngredienteId { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }

        public Ingrediente(int ingredienteId , string nombre, string unidad)
        {
            this.IngredienteId = ingredienteId;
            this.Nombre = nombre;
            this. Unidad = unidad;
        }

        public Ingrediente()
        {
           this.IngredienteId = 0;
           this.Nombre ="";
           this.Unidad="";
        }
        public override string ToString()
        {
            return "Ingrediente: " + Nombre;
        }


    }
}
